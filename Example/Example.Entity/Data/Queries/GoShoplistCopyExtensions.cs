using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoShoplistCopyExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoShoplistCopy? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoShoplistCopy> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoShoplistCopy?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoShoplistCopy> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> ByQShowtime(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, string qShowtime)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.QShowtime == qShowtime || (qShowtime == null && q.QShowtime == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> ByQUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, uint? qUid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.QUid == qUid || (qUid == null && q.QUid == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> ByRenqi(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, byte? renqi)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Renqi == renqi || (renqi == null && q.Renqi == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> ByShenyurenshu(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, uint? shenyurenshu)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Shenyurenshu == shenyurenshu || (shenyurenshu == null && q.Shenyurenshu == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> BySid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, uint sid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Sid == sid);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> ByYunjiage(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShoplistCopy> queryable, uint? yunjiage)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Yunjiage == yunjiage || (yunjiage == null && q.Yunjiage == null)));
    }

    #endregion

}
