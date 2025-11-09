using System.Security.Claims;
using AutoMapper;
using Core.Persistent.Repository;
using Core.Service;
using Core.Service.Base;
using Core.Service.Util;
using Core.WebApi.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;
using Sys.Entity.Response;
using ILogger = Serilog.ILogger;

namespace Sys.Service;

public class LoginService : BaseMgr, ILoginService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger = Log.ForContext<LoginService>();
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService; // 假设你有这个服务生成JWT

    public LoginService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper,
        IJwtService jwtService)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    /// <summary>
    /// 安全地序列化请求头
    /// </summary>
    private string SerializeRequestHeaders()
    {
        try
        {
            var headers = _httpContextAccessor.HttpContext?.Request.Headers;
            if (headers == null)
            {
                return "{}";
            }

            // 过滤敏感信息
            var safeHeaders = headers
                .Where(h => !IsSensitiveHeader(h.Key))
                .ToDictionary(h => h.Key, h => h.Value.ToString());

            return JsonConvert.SerializeObject(safeHeaders);
        }
        catch (Exception ex)
        {
            _logger.Warning(ex, "Failed to serialize request headers");
            return "{}";
        }
    }

    /// <summary>
    /// 判断是否是敏感请求头
    /// </summary>
    private bool IsSensitiveHeader(string headerName)
    {
        var sensitiveHeaders = new[] 
        { 
            "Authorization", 
            "Cookie", 
            "X-API-Key",
            "X-Auth-Token" 
        };

        return sensitiveHeaders.Contains(
            headerName, 
            StringComparer.OrdinalIgnoreCase);
    }
    public async Task<UserInfo> Login(LoginRequestParams loginRequestParams)
    {
        var ip = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        _logger.Information("登录请求 IP: {IP}, 用户名: {Username}, 请求体: {RequestJson}",
            ip, loginRequestParams.Username, JsonConvert.SerializeObject(loginRequestParams));
        
        loginRequestParams.Device = _httpContextAccessor.HttpContext?.Request?.Headers["User-Agent"];
        // === 1. 参数校验 ===
        if (string.IsNullOrWhiteSpace(loginRequestParams.Username) ||
            string.IsNullOrWhiteSpace(loginRequestParams.Password))
        {
            throw new ArgumentException("用户名或密码不能为空");
        }

        // === 2. 查询用户 ===
        var userEntity = await _unitOfWork.Repository<SysUser, Guid>()
            .Query()
            .Include(u => u.SysUserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(x => x.Username == loginRequestParams.Username);

        if (userEntity == null)
        {
            throw new AuthenticationFailureException("用户不存在");
        }

        // === 3. 校验密码 ===
        // 假设你有扩展方法 VerifyPassword(string raw, string salt, string hashed)
        if (!PasswordHelper.VerifyPassword(loginRequestParams.Password, userEntity.Salt, userEntity.Password))
        {
            throw new AuthenticationFailureException("用户名或密码错误");
        }

        // === 4. 映射 DTO（如果要返回用户信息） ===
        var userDto = _mapper.Map<SysUserDto>(userEntity);

        // === 5. 构造 Claims ===
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, userEntity.Username),
            new("uid", userEntity.Id.ToString())
        };

        if (userEntity.SysUserRoles.Any())
        {
            foreach (var role in userEntity.SysUserRoles.Select(r => r.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Code ?? role.Name));
            }
        }

        // === 6. 生成 Token ===
        var token = _jwtService.GenerateToken(claims);

       
        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            // === 7. 更新最后登录信息 ===
            userEntity.LastLoginIp = ip;
            userEntity.LastLoginTime = DateTime.UtcNow;
            _unitOfWork.Repository<SysUser, Guid>().Update(userEntity);
        
            SysLoginLog loginLog = new SysLoginLog
            {
                Ip = ip,
                Device = loginRequestParams.Device,
                Username = loginRequestParams.Username,
                LogDate = DateTime.Now,
                RequestHeader = SerializeRequestHeaders(),
                Status = 1,
            };
            await _unitOfWork.Repository<SysLoginLog, Guid>().AddAsync(loginLog);
        
            await _unitOfWork.SaveChangesAsync();
        });


        // === 8. 构造返回对象 ===
        var result = new UserInfo
        {
            Token = token,
            Username = userDto.Username,
            RealName = userDto.Name,
            Roles = userDto.Roles,
            LastLoginTime = userEntity.LastLoginTime
        };

        _logger.Information("用户 {Username} 登录成功，Token 已下发", userEntity.Username);

        return result;
    }
}
