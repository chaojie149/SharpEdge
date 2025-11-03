using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoLinkExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoLink? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoLink> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoLink> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoLink?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoLink> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoLink> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoLink> ByType(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoLink> queryable, byte type)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Type == type);
    }

    #endregion

}
