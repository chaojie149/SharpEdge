using Core.Persistent.Configuration;
using Core.Persistent.Context;
using Core.Persistent.Interceptors;
using Core.Persistent.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace Core.Persistent.Extensions;

/// <summary>
/// EF Core 持久层服务注册扩展
/// </summary>
/// <summary>
/// EF Core 持久层服务注册扩展
/// </summary>
public static class PersistenceServiceCollectionExtensions
{
    /// <summary>
    /// 添加持久层服务
    /// </summary>
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration,
        Func<IServiceCollection, DatabaseOptions, IServiceCollection>? registerExtraDbContexts = null)
    {
        // 1. 绑定配置
        var databaseOptions = configuration
            .GetSection(DatabaseOptions.SectionName)
            .Get<DatabaseOptions>() ?? new DatabaseOptions();

        services.Configure<DatabaseOptions>(
            configuration.GetSection(DatabaseOptions.SectionName));

        // 2. 注册拦截器
        services.AddSingleton<AuditInterceptor>();
        services.AddSingleton<QueryPerformanceInterceptor>(sp =>
            new QueryPerformanceInterceptor(
                sp.GetRequiredService<ILogger<QueryPerformanceInterceptor>>(),
                slowQueryThresholdMs: 1000));

        // // 3. 注册主数据库上下文
        // services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        // {
        //     ConfigureDbContext(options, databaseOptions, "Default", serviceProvider);
        // });

        registerExtraDbContexts?.Invoke(services, databaseOptions);

        // 4. 注册多数据源(如果配置了)
        // foreach (var dataSource in databaseOptions.DataSources)
        // {
        //     var dataSourceName = dataSource.Key;
        //     services.AddDbContext<DbContext>((serviceProvider, options) =>
        //     {
        //         ConfigureDbContext(options, databaseOptions, dataSourceName, serviceProvider);
        //     }, ServiceLifetime.Scoped);
        // }

        // 5. 注册仓储和工作单元
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(ISpecificationRepository<,>), typeof(SpecificationRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // 6. 注册 DbContext 工厂(用于多数据源切换)
        services.AddSingleton<IDbContextFactory>(serviceProvider =>
            new DbContextFactory(serviceProvider, databaseOptions));

        // 7. 注册缓存服务(可选)
        services.AddMemoryCache();
        // services.AddSingleton<IQueryCacheService, QueryCacheService>();

        return services;
    }

    /// <summary>
    /// 配置 DbContext 选项
    /// </summary>
    public static void ConfigureDbContext(
        DbContextOptionsBuilder options,
        DatabaseOptions databaseOptions,
        string dataSourceName,
        IServiceProvider serviceProvider)
    {
        // 获取数据源配置
        var dataSource = dataSourceName == "Default"
            ? new DataSourceOptions 
            { 
                ConnectionString = databaseOptions.DefaultConnection,
                Provider = DatabaseProvider.MySQL,
                EnableLogging = true
            }
            : databaseOptions.DataSources.GetValueOrDefault(dataSourceName) 
                ?? throw new InvalidOperationException($"Data source '{dataSourceName}' not found in configuration");

        // 根据数据库提供程序配置
        ConfigureDatabaseProvider(options, dataSource, databaseOptions);

        // 配置日志
        ConfigureLogging(options, dataSource, dataSourceName);

        // 配置开发环境选项
        ConfigureDevelopmentOptions(options, databaseOptions);

        // 添加拦截器
        AddInterceptors(options, serviceProvider);

        // 性能优化配置
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    /// <summary>
    /// 配置数据库提供程序
    /// </summary>
    private static void ConfigureDatabaseProvider(
        DbContextOptionsBuilder options,
        DataSourceOptions dataSource,
        DatabaseOptions databaseOptions)
    {
        switch (dataSource.Provider)
        {
            case DatabaseProvider.SqlServer:
                options.UseSqlServer(dataSource.ConnectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: databaseOptions.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay),
                        errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout(dataSource.CommandTimeout ?? databaseOptions.CommandTimeout);
                    sqlOptions.MigrationsAssembly(typeof(PersistenceServiceCollectionExtensions).Assembly.GetName().Name);
                });
                break;

          

            case DatabaseProvider.MySQL:
                options.UseMySql(
                    dataSource.ConnectionString,
                    ServerVersion.AutoDetect(dataSource.ConnectionString),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                        mysqlOptions.CommandTimeout(dataSource.CommandTimeout ?? databaseOptions.CommandTimeout);
                        mysqlOptions.MigrationsAssembly(typeof(PersistenceServiceCollectionExtensions).Assembly.GetName().Name);
                    });
                break;

            case DatabaseProvider.SQLite:
                options.UseSqlite(dataSource.ConnectionString, sqliteOptions =>
                {
                    sqliteOptions.CommandTimeout(dataSource.CommandTimeout ?? databaseOptions.CommandTimeout);
                    sqliteOptions.MigrationsAssembly(typeof(PersistenceServiceCollectionExtensions).Assembly.GetName().Name);
                });
                break;

            default:
                throw new NotSupportedException($"Database provider '{dataSource.Provider}' is not supported");
        }
    }

    /// <summary>
    /// 配置日志
    /// </summary>
    private static void ConfigureLogging(
        DbContextOptionsBuilder options,
        DataSourceOptions dataSource,
        string dataSourceName)
    {
        if (dataSource.EnableLogging)
        {
            options.LogTo(
                message => Log.Debug("[EF Core - {DataSource}] {Message}", dataSourceName, message),
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information,
                DbContextLoggerOptions.DefaultWithLocalTime);
        }
    }

    /// <summary>
    /// 配置开发环境选项
    /// </summary>
    private static void ConfigureDevelopmentOptions(
        DbContextOptionsBuilder options,
        DatabaseOptions databaseOptions)
    {
        if (databaseOptions.EnableSensitiveDataLogging)
        {
            options.EnableSensitiveDataLogging();
        }

        if (databaseOptions.EnableDetailedErrors)
        {
            options.EnableDetailedErrors();
        }
    }

    /// <summary>
    /// 添加拦截器
    /// </summary>
    private static void AddInterceptors(
        DbContextOptionsBuilder options,
        IServiceProvider serviceProvider)
    {
        // 添加审计拦截器
        var auditInterceptor = serviceProvider.GetService<AuditInterceptor>();
        if (auditInterceptor != null)
        {
            options.AddInterceptors(auditInterceptor);
        }

        // 添加性能监控拦截器
        var performanceInterceptor = serviceProvider.GetService<QueryPerformanceInterceptor>();
        if (performanceInterceptor != null)
        {
            options.AddInterceptors(performanceInterceptor);
        }
    }



}