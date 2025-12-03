namespace Sys.Entity.Params;

public class ResetPasswordParams
{
    public Guid Id { get; set; }
    
    public required string Password { get; set; }
}