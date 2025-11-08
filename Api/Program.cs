using Core.Persistent.Extensions;
using Example.Entity.Data;
using Example.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using Service.Jwt;
using Sys.Entity.Models;
using Sys.Service;

// ✅ 1. 在最开头配置 Serilog（使用 Bootstrap Logger）
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up FastNetPro.Api...");

    // ✅ 2. 创建 builder
    var builder = WebApplication.CreateBuilder(args);
// 配置JwtSettings
    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()!;

    // ✅ 3. 完整配置 Serilog（使用代码配置）
    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            
            // 所有日志输出到控制台
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
            
            // // EF Core 日志
            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(Matching.FromSource("Microsoft.EntityFrameworkCore.Database.Command"))
                .WriteTo.File(
                    path: "Logs/efcore-.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}"))
            
            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error || e.Level == LogEventLevel.Fatal)
                .WriteTo.File(
                    path: "Logs/err-.log",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 14,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}"))
            //
            // // Login 相关日志
            // .WriteTo.Logger(lc => lc
            //     .Filter.ByIncludingOnly(evt => 
            //         evt.Properties.ContainsKey("SourceContext") && 
            //         (evt.Properties["SourceContext"].ToString().Contains("LoginService") ||
            //          evt.Properties["SourceContext"].ToString().Contains("AuthController") ||
            //          evt.Properties["SourceContext"].ToString().Contains("UserService")))
            //     .WriteTo.File(
            //         path: "Logs/login-.log",
            //         rollingInterval: RollingInterval.Day,
            //         outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}"))
            //
            // // Order 相关日志
            // .WriteTo.Logger(lc => lc
            //     .Filter.ByIncludingOnly(evt => 
            //         evt.Properties.ContainsKey("SourceContext") && 
            //         (evt.Properties["SourceContext"].ToString().Contains("OrderService") ||
            //          evt.Properties["SourceContext"].ToString().Contains("OrderController")))
            //     .WriteTo.File(
            //         path: "Logs/order-.log",
            //         rollingInterval: RollingInterval.Day,
            //         outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}"))
            //
            // // Example 相关日志
            // .WriteTo.Logger(lc => lc
            //     .Filter.ByIncludingOnly(evt => 
            //         evt.Properties.ContainsKey("SourceContext") && 
            //         evt.Properties["SourceContext"].ToString().Contains("ExampleService"))
            //     .WriteTo.File(
            //         path: "Logs/example-.log",
            //         rollingInterval: RollingInterval.Day,
            //         outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}"))
            //
            // 所有日志的备份
            .WriteTo.File(
                path: "Logs/all-.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}");
    });


    builder.Services.AddControllers();
    builder.Services.AddOpenApi();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddPersistence(builder.Configuration, (services, databaseOptions) =>
    {
        // 这里注册 SysDbContext
        services.AddDbContext<SysDbContext>((serviceProvider, options) =>
        {
            PersistenceServiceCollectionExtensions.ConfigureDbContext(options, databaseOptions, "Default", serviceProvider);
            options.EnableSensitiveDataLogging(); // 开发环境用，生产慎用
            options.EnableDetailedErrors();
        });
        //
        // // 这里注册 TestdbContext
        // services.AddDbContext<TestdbContext>((serviceProvider, options) =>
        // {
        //     PersistenceServiceCollectionExtensions.ConfigureDbContext(options, databaseOptions, "Sys", serviceProvider);
        // });
        // services.AddScoped<DbContext, TestdbContext>();

        return services;
    });

    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<ExampleService>();
    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }
    app.UseSerilogRequestLogging();
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