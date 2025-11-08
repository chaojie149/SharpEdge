using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistent.Extensions;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public static class BulkOperationExtensions
{
    // 批量插入(使用 EF Core 9 的批量操作)
    public static async Task BulkInsertAsync<T>(
        this DbContext context,
        IEnumerable<T> entities,
        int batchSize = 1000,
        CancellationToken cancellationToken = default) where T : class
    {
        var entityList = entities.ToList();
        var totalBatches = (int)Math.Ceiling(entityList.Count / (double)batchSize);

        for (int i = 0; i < totalBatches; i++)
        {
            var batch = entityList.Skip(i * batchSize).Take(batchSize);
            await context.Set<T>().AddRangeAsync(batch, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            context.ChangeTracker.Clear(); // 清理跟踪以提高性能
        }
    }

    // 批量更新
    public static async Task BulkUpdateAsync<T>(
        this DbContext context,
        IEnumerable<T> entities,
        int batchSize = 1000,
        CancellationToken cancellationToken = default) where T : class
    {
        var entityList = entities.ToList();
        var totalBatches = (int)Math.Ceiling(entityList.Count / (double)batchSize);

        for (int i = 0; i < totalBatches; i++)
        {
            var batch = entityList.Skip(i * batchSize).Take(batchSize);
            context.Set<T>().UpdateRange(batch);
            await context.SaveChangesAsync(cancellationToken);
            context.ChangeTracker.Clear();
        }
    }

    // 批量删除
    public static async Task<int> BulkDeleteAsync<T>(
        this DbContext context,
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default) where T : class
    {
        return await context.Set<T>()
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
    }

    // 批量更新特定字段(EF Core 7+)
    public static async Task<int> BulkUpdatePropertyAsync<T>(
        this DbContext context,
        Expression<Func<T, bool>> predicate,
        Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls,
        CancellationToken cancellationToken = default) where T : class
    {
        return await context.Set<T>()
            .Where(predicate)
            .ExecuteUpdateAsync(setPropertyCalls, cancellationToken);
    }
}