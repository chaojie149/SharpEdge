using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberRecodesExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoMemberRecodes? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRecodes> queryable, int id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberRecodes> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoMemberRecodes?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRecodes> queryable, int id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoMemberRecodes> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRecodes> ByType(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRecodes> queryable, bool type)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Type == type);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRecodes> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRecodes> queryable, uint uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    #endregion

}
