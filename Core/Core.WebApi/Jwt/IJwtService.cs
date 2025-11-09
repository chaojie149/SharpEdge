using System.Security.Claims;

namespace Core.WebApi.Jwt;

public interface IJwtService
{
    string GenerateToken(IEnumerable<Claim> claims);
    ClaimsPrincipal? ValidateToken(string token);
}