using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoNavigationExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoNavigation? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> queryable, ushort cid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoNavigation> dbSet)
            return dbSet.Find(cid);

        return queryable.FirstOrDefault(q => q.Cid == cid);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoNavigation?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> queryable, ushort cid, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoNavigation> dbSet)
            return await dbSet.FindAsync(new object[] { cid }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Cid == cid, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> ByOrder(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> queryable, ushort? order)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Order == order || (order == null && q.Order == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> ByStatus(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> queryable, string status)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Status == status || (status == null && q.Status == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> ByType(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoNavigation> queryable, string type)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Type == type || (type == null && q.Type == null)));
    }

    #endregion

}
