using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoEgglotterRuleExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoEgglotterRule? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoEgglotterRule> queryable, int ruleId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoEgglotterRule> dbSet)
            return dbSet.Find(ruleId);

        return queryable.FirstOrDefault(q => q.RuleId == ruleId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoEgglotterRule?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoEgglotterRule> queryable, int ruleId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoEgglotterRule> dbSet)
            return await dbSet.FindAsync(new object[] { ruleId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.RuleId == ruleId, cancellationToken);
    }

    #endregion

}
