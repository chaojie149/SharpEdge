using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Service.Cache;
using Microsoft.AspNetCore.Http;

namespace Core.Service.Base;

public class ServiceOperator
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static readonly string AnonymousUser = "Anonymous User";
    
    private readonly IRedisManager _redis;

    public ServiceOperator(IHttpContextAccessor httpContextAccessor, IRedisManager redis)
    {
        _httpContextAccessor = httpContextAccessor;
        _redis = redis;
    }

    public bool IsTokenBlacklisted()
    {
        var token = AccessToken;
        if (string.IsNullOrEmpty(token)) return true;

        var handler = new JwtSecurityTokenHandler();
        if (!handler.CanReadToken(token)) return true;

        var jti = handler.ReadJwtToken(token)
            .Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;

        if (string.IsNullOrEmpty(jti)) return false;

        return _redis.KeyExistsAsync($"jwt:black:{jti}").Result;
    }
    
    /// <summary>
    /// 当前登录用户名
    /// </summary>
    public string UserName
    {
        get
        {
            var name = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            return string.IsNullOrEmpty(name) ? AnonymousUser : name;
        }
    }

    /// <summary>
    /// 当前登录用户ID（从Token中uid claim读取）
    /// </summary>
    public string? UserId =>
        _httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value;

    /// <summary>
    /// 当前登录用户角色（多个角色Claim）
    /// </summary>
    public List<string> UserRoles =>
        _httpContextAccessor.HttpContext?.User?
            .FindAll(ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList() ?? new List<string>();

    /// <summary>
    /// 原始JWT Token字符串
    /// </summary>
    public string? AccessToken
    {
        get
        {
            var header = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(header)) return null;
            return header.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
                ? header.Substring("Bearer ".Length).Trim()
                : header;
        }
    }

    /// <summary>
    /// 原始ClaimsPrincipal
    /// </summary>
    public ClaimsPrincipal? UserClaims => _httpContextAccessor.HttpContext?.User;

    /// <summary>
    /// 获取指定Claim值
    /// </summary>
    public string? GetClaim(string claimType) =>
        _httpContextAccessor.HttpContext?.User?.FindFirst(claimType)?.Value;

    /// <summary>
    /// 获取Token解析后的payload（可选）
    /// </summary>
    public IDictionary<string, object>? TokenPayload
    {
        get
        {
            if (string.IsNullOrEmpty(AccessToken)) return null;
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(AccessToken)) return null;
            var token = handler.ReadJwtToken(AccessToken);
            return token.Payload;
        }
    }
}
