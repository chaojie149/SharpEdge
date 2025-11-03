using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoShaidanExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoShaidan? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint sdId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoShaidan> dbSet)
            return dbSet.Find(sdId);

        return queryable.FirstOrDefault(q => q.SdId == sdId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoShaidan?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint sdId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoShaidan> dbSet)
            return await dbSet.FindAsync(new object[] { sdId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.SdId == sdId, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> BySdPing(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint? sdPing)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.SdPing == sdPing || (sdPing == null && q.SdPing == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> BySdShopid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint? sdShopid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.SdShopid == sdShopid || (sdShopid == null && q.SdShopid == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> BySdTime(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint? sdTime)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.SdTime == sdTime || (sdTime == null && q.SdTime == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> BySdUserid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint? sdUserid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.SdUserid == sdUserid || (sdUserid == null && q.SdUserid == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> BySdZhan(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShaidan> queryable, uint? sdZhan)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.SdZhan == sdZhan || (sdZhan == null && q.SdZhan == null)));
    }

    #endregion

}
