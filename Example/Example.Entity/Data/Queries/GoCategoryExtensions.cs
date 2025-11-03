using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoCategoryExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoCategory? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCategory> queryable, ushort cateid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoCategory> dbSet)
            return dbSet.Find(cateid);

        return queryable.FirstOrDefault(q => q.Cateid == cateid);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoCategory?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCategory> queryable, ushort cateid, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoCategory> dbSet)
            return await dbSet.FindAsync(new object[] { cateid }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Cateid == cateid, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoCategory> ByName(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCategory> queryable, string name)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Name == name || (name == null && q.Name == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoCategory> ByOrder(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCategory> queryable, ushort? order)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Order == order || (order == null && q.Order == null)));
    }

    #endregion

}
