using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoPay3Extensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoPay3? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoPay3> queryable, uint payId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoPay3> dbSet)
            return dbSet.Find(payId);

        return queryable.FirstOrDefault(q => q.PayId == payId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoPay3?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoPay3> queryable, uint payId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoPay3> dbSet)
            return await dbSet.FindAsync(new object[] { payId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.PayId == payId, cancellationToken);
    }

    #endregion

}
