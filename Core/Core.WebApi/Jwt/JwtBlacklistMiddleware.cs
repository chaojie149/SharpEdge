using System.IdentityModel.Tokens.Jwt;
using Core.Service.Cache;
using Microsoft.AspNetCore.Http;

namespace Core.WebApi.Jwt;

public class JwtBlacklistMiddleware(RequestDelegate next, IRedisManager redis)
{
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

        await next(context);
    }

}