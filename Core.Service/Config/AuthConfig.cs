namespace Core.Service.Config;

/// <summary>
/// JWT 授权配置
/// </summary>
public class AuthConfig
{
    /// <summary>
    /// 访问令牌过期时间（分钟）
    /// </summary>
    public int Expire { get; set; } = 120;

    /// <summary>
    /// HTTP 请求头字段名，例如 "Authorization"
    /// </summary>
    public string HeadField { get; set; } = "Authorization";

    /// <summary>
    /// Token 前缀，例如 "Bearer"
    /// </summary>
    public string Prefix { get; set; } = "Bearer";

    /// <summary>
    /// 续签时间（分钟），即 Token 剩余多久会触发自动刷新
    /// </summary>
    public int RenewalTime { get; set; } = 30;

    /// <summary>
    /// 签发者（可选，用于验证）
    /// </summary>
    public string Issuer { get; set; } = "CoreWebApi";

    /// <summary>
    /// 接收者（可选，用于验证）
    /// </summary>
    public string Audience { get; set; } = "CoreWebApiUsers";

    /// <summary>
    /// 签名密钥（必填）
    /// </summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>
    /// 忽略验证的 URL 列表
    /// </summary>
    public List<string> IgnoreUrls { get; set; } = new();

    public override string ToString()
    {
        var ignoreUrlsStr = IgnoreUrls != null && IgnoreUrls.Any()
            ? string.Join(", ", IgnoreUrls.Select(url => $"'{url}'"))
            : "None";

        return $@"AuthConfig:
  Expire: {Expire} minutes
  RenewalTime: {RenewalTime} minutes
  HeadField: '{HeadField}'
  Prefix: '{Prefix}'
  Issuer: '{Issuer}'
  Audience: '{Audience}'
  SecretKey: '{(string.IsNullOrEmpty(SecretKey) ? "(not set)" : "*** hidden ***")}'
  IgnoreUrls: [{ignoreUrlsStr}]";
    }
}