using Core.Service.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace Core.Service.GlobalConfig;

public static class AppGlobalSettings
{
    public static readonly string FinalRole = "Administrator";

    private static readonly ILogger Logger = Log.ForContext(typeof(AppGlobalSettings));
    public static IConfiguration? Configuration { get; private set; }
    public static Secret? Secret { get; private set; }

    public static AuthConfig? AuthConfig { get; set; }

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
        Logger.Information("🧩 Global settings loaded successfully:");
        Logger.Information("AuthConfig => HeadField: {Issuer}, Prefix: {Audience}",
            AuthConfig?.HeadField, AuthConfig?.Prefix);
        Logger.Information("FinalRole => {FinalRole}", FinalRole);
    }
}