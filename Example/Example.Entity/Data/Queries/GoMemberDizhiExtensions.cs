using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberDizhiExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberDizhi? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberDizhi> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberDizhi> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberDizhi?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberDizhi> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberDizhi> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberDizhi> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberDizhi> queryable, int uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    #endregion

}
