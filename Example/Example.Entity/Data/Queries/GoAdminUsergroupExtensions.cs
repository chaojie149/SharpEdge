using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoAdminUsergroupExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoAdminUsergroup? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoAdminUsergroup> queryable, int mid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoAdminUsergroup> dbSet)
            return dbSet.Find(mid);

        return queryable.FirstOrDefault(q => q.Mid == mid);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoAdminUsergroup?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoAdminUsergroup> queryable, int mid, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoAdminUsergroup> dbSet)
            return await dbSet.FindAsync(new object[] { mid }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Mid == mid, cancellationToken);
    }

    #endregion

}
