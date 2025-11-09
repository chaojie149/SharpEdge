using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Core.Persistent.Repository;
using Core.Service.Base;
using Core.Service.Cache;
using Core.Service.Util;
using Core.WebApi.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;
using Sys.Entity.Response;
using DateTimeUtil = Core.Service.Util.DateTimeUtil;
using ILogger = Serilog.ILogger;

namespace Sys.Service.Service;

public class LoginService : BaseMgr, ILoginService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger = Log.ForContext<LoginService>();
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService; // 假设你有这个服务生成JWT

    private readonly IRedisManager _redisManager;


    public LoginService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, IJwtService jwtService, IRedisManager redisManager)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _jwtService = jwtService;
        _redisManager = redisManager;
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

        var refreshToken = Guid.NewGuid().ToString("N"); // 可随机字符串
        
        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            // === 7. 更新最后登录信息 ===
            userEntity.LastLoginIp = ip;
            userEntity.LastLoginTime = DateTime.Now;
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
        
        //redis保存refresh token
        await _redisManager.StringSetAsync(CacheKey.JwtRefreshKey + userDto.Id, refreshToken, TimeSpan.FromDays(7));

        // === 8. 构造返回对象 ===
        var result = new UserInfo
        {
            Token = token,
            RefreshToken = refreshToken,
            Username = userDto.Username,
            RealName = userDto.Name,
            Roles = userDto.Roles,
            LastLoginTime = userEntity.LastLoginTime,
            Email = userDto.Email
        };

        _logger.Information("用户 {Username} 登录成功，Token 已下发", userEntity.Username);

        return result;
    }

    public async Task<UserInfo> RefreshToken(string refreshToken)
    {
        var token = ServiceOperator.AccessToken;
        if (string.IsNullOrWhiteSpace(token))
            throw new AuthenticationFailureException("未提供 Token");

        var principal = _jwtService.ValidateToken(token);
        string? userId = ServiceOperator.UserId;
        
        var jti = principal?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
        var exp = principal?.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(jti) || string.IsNullOrEmpty(exp))
            throw new AuthenticationFailureException("token无效");
        
        string? cacheRefreshToken = await _redisManager.StringGetAsync(CacheKey.JwtRefreshKey + userId);
        
        if (userId == null || cacheRefreshToken == null || ServiceOperator.AccessToken == null)
        {
            throw new SecurityTokenExpiredException("token无效");
        }

        if (refreshToken != cacheRefreshToken)
        {
            throw new SecurityTokenExpiredException("token刷新失败");
        }
        
        // === 2. 查询用户 ===
        var userEntity = await _unitOfWork.Repository<SysUser, Guid>()
            .Query()
            .Include(u => u.SysUserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(x => x.Id == new Guid(userId));
        
        var userDto = _mapper.Map<SysUserDto>(userEntity);
        
        if (userEntity == null)
        {
            throw new SecurityTokenExpiredException("token无效");
        }
        
        // === 5. 构造 Claims ===
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, userEntity.Username),
            new("uid", userEntity.Id.ToString()!)
        };
        if (userEntity.SysUserRoles.Any())
        {
            foreach (var role in userEntity.SysUserRoles.Select(r => r.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Code ?? role.Name));
            }
        }
        
        
        var newAccessToken = _jwtService.GenerateToken(claims);
        var newRefreshToken = Guid.NewGuid().ToString("N");
        
        //redis保存refresh token
        await _redisManager.StringSetAsync(CacheKey.JwtRefreshKey + userId  , newRefreshToken, TimeSpan.FromDays(7));
        

        // var expireAt = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp)).DateTime;
        var expireAt = DateTimeUtil.GetDateTimeByTimeStamp(long.Parse(exp));
        var ttl = expireAt - DateTime.Now;
        if (ttl.TotalSeconds <= 0)
            ttl = TimeSpan.FromMinutes(1); // 至少保留 1 分钟防御性写入
        //旧的token加入黑名单
        await _redisManager.StringSetAsync(CacheKey.JwtBlackKey + jti, ServiceOperator.AccessToken!, ttl);

        // === 8. 构造返回对象 ===
        var result = new UserInfo
        {
            Token = newAccessToken,
            RefreshToken = newRefreshToken,
            Username = userDto.Username,
            RealName = userDto.Name,
            Roles = userDto.Roles,
            LastLoginTime = userEntity.LastLoginTime,
            Email = userDto.Email
        };

        _logger.Information("用户 {Username} 刷新Token成功，Token 已下发 RefreshToken {RefreshToken} NewAccessToken {Token}", userEntity.Username,result.RefreshToken,result.Token);

        return result;
    }

    public async Task Logout()
    {
        var token = ServiceOperator.AccessToken;
        if (string.IsNullOrWhiteSpace(token))
            throw new AuthenticationFailureException("未提供 Token");

        var principal = _jwtService.ValidateToken(token);
        var userId = principal?.FindFirst("uid")?.Value;
        var jti = principal?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
        var exp = principal?.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;

        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(jti) || string.IsNullOrEmpty(exp))
            throw new AuthenticationFailureException("无效 Token");

        // 删除 RefreshToken
        await _redisManager.KeyDeleteAsync(CacheKey.JwtRefreshKey + userId);

        var expireAt = DateTimeUtil.GetDateTimeByTimeStamp(long.Parse(exp));
        var ttl = expireAt - DateTime.Now;
        if (ttl.TotalSeconds <= 0)
            ttl = TimeSpan.FromMinutes(1); // 至少保留 1 分钟防御性写入
        await _redisManager.StringSetAsync(CacheKey.JwtBlackKey + jti, ServiceOperator.AccessToken!, ttl);

        _logger.Information("用户 {UserId} 已登出，token 加入黑名单", userId);
    }
}
