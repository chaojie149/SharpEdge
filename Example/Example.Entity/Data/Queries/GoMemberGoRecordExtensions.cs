using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberGoRecordExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberGoRecord? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberGoRecord> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberGoRecord?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberGoRecord> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> ByShopid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> queryable, uint shopid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Shopid == shopid);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> ByTime(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> queryable, string time)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Time == time);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGoRecord> queryable, uint uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    #endregion

}
