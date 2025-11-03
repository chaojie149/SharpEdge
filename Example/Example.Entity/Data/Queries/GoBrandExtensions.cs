using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoBrandExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoBrand? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoBrand> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoBrand> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoBrand?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoBrand> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoBrand> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoBrand> ByOrder(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoBrand> queryable, int? order)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Order == order || (order == null && q.Order == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoBrand> ByStatus(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoBrand> queryable, string status)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Status == status || (status == null && q.Status == null)));
    }

    #endregion

}
