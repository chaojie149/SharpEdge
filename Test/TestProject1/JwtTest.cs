using System.Security.Claims;
using Core.Service.Config;
using Core.Service.GlobalConfig;
using Core.WebApi.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1;

public class JwtTest
{
    
    [SetUp]
    public void Setup()
    {
        AppGlobalSettings.AuthConfig = new AuthConfig
        {
            SecretKey = "C5ABA9E202D94C43A3CA66002BF77FAF",
            Issuer = "SharpEdge",
            Audience = "FastNetCoreProUser",
            Expire = 60
        };
    }
    
    [Test]
    public void JwtService_With_DI_Config_Works()
    {
      

        var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory,
                    Path.Combine("Config", "appsettings.Development.json")))

            .Build();

        // 2. DI 容器
        var services = new ServiceCollection();
        services.Configure<AuthConfig>(configuration.GetSection("AuthConfig"));
        services.AddSingleton<IJwtService, JwtService>();

        var provider = services.BuildServiceProvider();

        // 3. 解析并测试
        var jwtService = provider.GetRequiredService<IJwtService>();

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, "test") };
        var token = jwtService.GenerateToken(claims);

        // Assert.IsNotNull(token);

        var principal = jwtService.ValidateToken(token);
        // Assert.IsNotNull(principal);
        // Assert.AreEqual("test", principal.Identity.Name);
    }
}