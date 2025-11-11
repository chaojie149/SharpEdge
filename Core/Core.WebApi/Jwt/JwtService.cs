using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Service.GlobalConfig;
using Microsoft.IdentityModel.Tokens;

namespace Core.WebApi.Jwt;

public class JwtService : IJwtService
{
    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppGlobalSettings.AuthConfig.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 确保 jti 存在
        var claimsList = claims.ToList();
        if (claimsList.All(c => c.Type != JwtRegisteredClaimNames.Jti))
        {
            claimsList.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        }

        var token = new JwtSecurityToken(
            issuer: AppGlobalSettings.AuthConfig.Issuer,
            audience: AppGlobalSettings.AuthConfig.Audience,
            claims: claimsList,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(AppGlobalSettings.AuthConfig.Expire),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppGlobalSettings.AuthConfig.SecretKey));
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            return tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = AppGlobalSettings.AuthConfig.Issuer,
                ValidAudience = AppGlobalSettings.AuthConfig.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            }, out _);
        }
        catch
        {
            return null;
        }
    }
}