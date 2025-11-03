using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberGroupExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberGroup? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGroup> queryable, byte groupid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberGroup> dbSet)
            return dbSet.Find(groupid);

        return queryable.FirstOrDefault(q => q.Groupid == groupid);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberGroup?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGroup> queryable, byte groupid, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberGroup> dbSet)
            return await dbSet.FindAsync(new object[] { groupid }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Groupid == groupid, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGroup> ByJingyanStart(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberGroup> queryable, uint jingyanStart)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.JingyanStart == jingyanStart);
    }

    #endregion

}
