namespace Sys.Entity.Response;

public class LoginResponse
{
    public required string Token { get; set; }
        
    public required string RefreshToken { get; set; }
    
    public required UserInfo UserInfo { get; set; }
}