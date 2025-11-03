using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoEgglotterAwardExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoEgglotterAward? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoEgglotterAward> queryable, int awardId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoEgglotterAward> dbSet)
            return dbSet.Find(awardId);

        return queryable.FirstOrDefault(q => q.AwardId == awardId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoEgglotterAward?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoEgglotterAward> queryable, int awardId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoEgglotterAward> dbSet)
            return await dbSet.FindAsync(new object[] { awardId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.AwardId == awardId, cancellationToken);
    }

    #endregion

}
