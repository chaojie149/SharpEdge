using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Core.Persistent.Interceptors;

public class QueryPerformanceInterceptor : DbCommandInterceptor
{
    private readonly ILogger<QueryPerformanceInterceptor> _logger;
    private readonly int _slowQueryThresholdMs;

    public QueryPerformanceInterceptor(
        ILogger<QueryPerformanceInterceptor> logger,
        int slowQueryThresholdMs = 1000)
    {
        _logger = logger;
        _slowQueryThresholdMs = slowQueryThresholdMs;
    }

    public override async ValueTask<DbDataReader> ReaderExecutedAsync(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result,
        CancellationToken cancellationToken = default)
    {
        var duration = eventData.Duration.TotalMilliseconds;

        if (duration > _slowQueryThresholdMs)
        {
            _logger.LogWarning(
                "Slow query detected: {Duration}ms | SQL: {CommandText}",
                duration,
                command.CommandText);
        }

        return await base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override async ValueTask<int> NonQueryExecutedAsync(
        DbCommand command,
        CommandExecutedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        var duration = eventData.Duration.TotalMilliseconds;

        if (duration > _slowQueryThresholdMs)
        {
            _logger.LogWarning(
                "Slow command detected: {Duration}ms | SQL: {CommandText}",
                duration,
                command.CommandText);
        }

        return await base.NonQueryExecutedAsync(command, eventData, result, cancellationToken);
    }
}