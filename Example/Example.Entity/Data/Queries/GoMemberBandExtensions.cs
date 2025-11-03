using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberBandExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberBand? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberBand> queryable, uint bId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberBand> dbSet)
            return dbSet.Find(bId);

        return queryable.FirstOrDefault(q => q.BId == bId);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberBand?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberBand> queryable, uint bId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberBand> dbSet)
            return await dbSet.FindAsync(new object[] { bId }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.BId == bId, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberBand> ByBUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberBand> queryable, int? bUid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.BUid == bUid || (bUid == null && q.BUid == null)));
    }

    #endregion

}
