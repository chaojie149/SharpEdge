using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoEgglotterSpoilExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoEgglotterSpoil? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoEgglotterSpoil> queryable, int spoilId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoEgglotterSpoil> dbSet)
            return dbSet.Find(spoilId);

        return queryable.FirstOrDefault(q => q.SpoilId == spoilId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoEgglotterSpoil?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoEgglotterSpoil> queryable, int spoilId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoEgglotterSpoil> dbSet)
            return await dbSet.FindAsync(new object[] { spoilId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.SpoilId == spoilId, cancellationToken);
    }

    #endregion

}
