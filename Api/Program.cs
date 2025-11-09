using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Persistent.Extensions;
using Core.Service;
using Core.Service.Auth;
using Core.Service.Config;
using Core.Service.GlobalConfig;
using Core.WebApi.Jwt;
using Core.WebApi.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Scalar.AspNetCore;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using Sys.Entity.Models;
using Sys.Service;
using Sys.WebApi;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up FastNetPro.Api...");

    var builder = WebApplication.CreateBuilder(args);

    // ✅ 使用 Autofac
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
  

    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog();

    // ✅ 完整 Serilog 配置
    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft.*", LogEventLevel.Warning)
           

            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            .WriteTo.Console(outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(Matching.FromSource("Microsoft.EntityFrameworkCore.Database.Command"))
                .WriteTo.File("Logs/efcore-.log", rollingInterval: RollingInterval.Day))
            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error || e.Level == LogEventLevel.Fatal)
                .WriteTo.File("Logs/err-.log", rollingInterval: RollingInterval.Day))
            .WriteTo.File("Logs/all-.log", rollingInterval: RollingInterval.Day);
    });

    builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

    builder.Services.AddOpenApi();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddGlobalSettings(builder.Configuration);

    // ✅ DbContext
    builder.Services.AddPersistence(builder.Configuration, (services, databaseOptions) =>
    {
        services.AddDbContext<SysDbContext>((serviceProvider, options) =>
        {
            PersistenceServiceCollectionExtensions.ConfigureDbContext(
                options, databaseOptions, "Default", serviceProvider);
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });
        services.AddScoped<DbContext, SysDbContext>();
        return services;
    });
    // ✅ JWT
    builder.Services.AddSingleton<IJwtService,JwtService>();
    
    //模块注入
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.AddCoreServices();        // ✅ 注册 Core 层 ServiceOperator
        containerBuilder.AddSysServices();
        containerBuilder.AddSysServiceAutoMapper();
        
    });    
    builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer(options =>
        {
            var auth = builder.Configuration.GetSection("Auth").Get<AuthConfig>()!;
            var key = Encoding.UTF8.GetBytes(auth.SecretKey);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = auth.Issuer,
                ValidAudience = auth.Audience,
                ClockSkew = TimeSpan.Zero
            };
        });
    
    builder.Services.AddSysControllers();
    
    
    builder.Services.AddEndpointsApiExplorer();
    
    var app = builder.Build();

    
  
    
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }



    app.UseSerilogRequestLogging();
    app.UseExceptionHandlerMiddleware();

    app.UseAuthentication(); // ✅ 必须在授权前
    app.UseAuthorization();

    app.MapControllers();

    Log.Information("Application started successfully!");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly!");
}
finally
{
    Log.CloseAndFlush();
}
