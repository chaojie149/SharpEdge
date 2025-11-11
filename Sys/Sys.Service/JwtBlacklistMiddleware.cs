using System.IdentityModel.Tokens.Jwt;
using Core.Service.Cache;
using Microsoft.AspNetCore.Http;
using Sys.Service.Service;

namespace Sys.Service;

public class JwtBlacklistMiddleware(RequestDelegate next, IRedisManager redis)
{
    
    private readonly ILoginService _authService;

    public JwtBlacklistMiddleware(RequestDelegate next, IRedisManager redis, ILoginService authService) : this(next, redis)
    {
        _authService = authService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (string.IsNullOrEmpty(token))
        {
            await next(context);
            return;
        }

        var handler = new JwtSecurityTokenHandler();
        if (!handler.CanReadToken(token))
        {
            await next(context);
            return;
        }

        var jti = handler.ReadJwtToken(token)
            .Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;

        if (!string.IsNullOrEmpty(jti))
        {
            var key = $"{CacheKey.JwtBlackKey}{jti}";
            if (await redis.KeyExistsAsync(key))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token已失效");
                return;
            }
        }
        var jwt = handler.ReadJwtToken(token);
        var exp = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;

        if (long.TryParse(exp, out var expSeconds))
        {
            var expireAt = DateTimeOffset.FromUnixTimeSeconds(expSeconds).UtcDateTime;
            var remaining = expireAt - DateTime.UtcNow;

            // token 剩余 < 5 分钟就刷新
            if (remaining.TotalMinutes < 30)
            {
                var userId = jwt.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
                var refreshToken = context.Request.Headers["X-Refresh-Token"].ToString();

                // 调用 RefreshToken() 方法生成新的 token
                var refreshed = await _authService.RefreshToken(refreshToken);

                // 写回响应头
                context.Response.Headers["Authorization"] = $"Bearer {refreshed.Token}";
                context.Response.Headers["X-Refresh-Token"] = refreshed.RefreshToken;
            }
        }
        

        await next(context);
    }

}