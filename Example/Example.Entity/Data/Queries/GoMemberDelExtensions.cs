using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberDelExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberDel? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberDel> queryable, uint uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberDel> dbSet)
            return dbSet.Find(uid);

        return queryable.FirstOrDefault(q => q.Uid == uid);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberDel?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberDel> queryable, uint uid, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberDel> dbSet)
            return await dbSet.FindAsync(new object[] { uid }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Uid == uid, cancellationToken);
    }

    #endregion

}
