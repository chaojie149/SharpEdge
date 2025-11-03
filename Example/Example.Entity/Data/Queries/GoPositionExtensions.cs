using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoPositionExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoPosition? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoPosition> queryable, uint posId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoPosition> dbSet)
            return dbSet.Find(posId);

        return queryable.FirstOrDefault(q => q.PosId == posId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoPosition?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoPosition> queryable, uint posId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoPosition> dbSet)
            return await dbSet.FindAsync(new object[] { posId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.PosId == posId, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoPosition> ByPosModel(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoPosition> queryable, byte posModel)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.PosModel == posModel);
    }

    #endregion

}
