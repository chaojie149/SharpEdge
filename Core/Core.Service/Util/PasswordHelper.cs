namespace Core.Service.Util;

public static class PasswordHelper
{
    public static bool VerifyPassword(string plain, string salt, string hashed)
    {
        var hash = HashPassword(plain, salt);
        return hash == hashed;
    }

    public static string HashPassword(string plain, string salt)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(plain + salt);
        var hashBytes = sha256.ComputeHash(bytes);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}