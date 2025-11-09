using Core.Service.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace Core.Service.GlobalConfig;

public static class AppGlobalSettings
{
    public static string FinalRole = "Administrator";

    private static readonly ILogger _logger = Log.ForContext(typeof(AppGlobalSettings));
    public static IConfiguration Configuration { get; private set; }
    public static Secret Secret { get; private set; }

    public static AuthConfig AuthConfig { get; private set; }

    public static IServiceCollection AddGlobalSettings(this IServiceCollection services, IConfiguration configuration)
    {
        Configuration = configuration;
        services.Configure<Secret>(configuration.GetSection("Secret"));
        services.Configure<AuthConfig>(configuration.GetSection("Auth"));
        var provider = services.BuildServiceProvider();
        Secret = provider.GetRequiredService<IOptions<Secret>>().Value;
        AuthConfig = provider.GetRequiredService<IOptions<AuthConfig>>().Value;
        PrinterSettings();

        return services;
    }

    public static void PrinterSettings()
    {
        // ✅ 在静态方法中直接使用 _logger
        _logger.Information("🧩 Global settings loaded successfully:");
        _logger.Information("AuthConfig => HeadField: {Issuer}, Prefix: {Audience}",
            AuthConfig?.HeadField, AuthConfig?.Prefix);
        _logger.Information("Secret => Key: {Key}", Secret?.Key);
        _logger.Information("FinalRole => {FinalRole}", FinalRole);
    }
}