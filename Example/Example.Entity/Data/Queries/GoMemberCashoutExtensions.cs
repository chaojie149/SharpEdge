using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberCashoutExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberCashout? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberCashout> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberCashout> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberCashout?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberCashout> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberCashout> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberCashout> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberCashout> queryable, uint uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberCashout> ByUsername(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberCashout> queryable, string username)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Username == username);
    }

    #endregion

}
