using System.Reflection;
using Core.Persistent.Configuration;
using Core.Persistent.Extensions;
using Example.Entity.Data;
using Example.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
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

    // ✅ 3. 完整配置 Serilog（使用代码配置）
    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            
            // 所有日志输出到控制台
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
            
            // // EF Core 日志
            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(Matching.FromSource("Microsoft.EntityFrameworkCore"))
                .WriteTo.File(
                    path: "Logs/efcore-.log",
                    rollingInterval: RollingInterval.Day,
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

    // 4️⃣ 注册服务
    builder.Services.AddControllers();
    builder.Services.AddOpenApi();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddPersistence(builder.Configuration, (services, databaseOptions) =>
    {
        // 这里注册 SysDbContext
        services.AddDbContext<SysDbContext>((serviceProvider, options) =>
        {
            PersistenceServiceCollectionExtensions.ConfigureDbContext(options, databaseOptions, "Default", serviceProvider);
        });
        
        // 这里注册 TestdbContext
        services.AddDbContext<TestdbContext>((serviceProvider, options) =>
        {
            PersistenceServiceCollectionExtensions.ConfigureDbContext(options, databaseOptions, "Sys", serviceProvider);
        });
        services.AddScoped<DbContext, TestdbContext>();

        return services;
    });

    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<ExampleService>();
    builder.Services.AddEndpointsApiExplorer();

    // 5️⃣ 构建应用
    var app = builder.Build();

    // 6️⃣ 中间件
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseAuthorization();
    app.MapControllers();
    
    // ✅ 添加 Serilog 请求日志（放在 UseAuthorization 之后）
    app.UseSerilogRequestLogging();

    // ✅ 启动日志
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