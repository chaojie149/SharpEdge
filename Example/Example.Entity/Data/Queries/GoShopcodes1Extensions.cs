using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoShopcodes1Extensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoShopcodes1? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoShopcodes1> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoShopcodes1?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoShopcodes1> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> BySCid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> queryable, ushort sCid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.SCid == sCid);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> BySId(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> queryable, uint sId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.SId == sId);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> BySLen(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoShopcodes1> queryable, short? sLen)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.SLen == sLen || (sLen == null && q.SLen == null)));
    }

    #endregion

}
