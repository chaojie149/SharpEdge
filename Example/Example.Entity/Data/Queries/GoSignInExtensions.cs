using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoSignInExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoSignIn? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> queryable, int id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoSignIn> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoSignIn?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> queryable, int id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoSignIn> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> BySignDate(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> queryable, DateOnly signDate)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.SignDate == signDate);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> queryable, int uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    public static Example.Entity.Data.Entities.GoSignIn? GetByUidSignDate(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> queryable, int uid, DateOnly signDate)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.FirstOrDefault(q => q.Uid == uid
            && q.SignDate == signDate);
    }

    public static async System.Threading.Tasks.Task<Example.Entity.Data.Entities.GoSignIn?> GetByUidSignDateAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoSignIn> queryable, int uid, DateOnly signDate, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return await queryable.FirstOrDefaultAsync(q => q.Uid == uid
            && q.SignDate == signDate, cancellationToken);
    }

    #endregion

}
