using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoCardPwdExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoCardPwd? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCardPwd> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoCardPwd> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoCardPwd?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCardPwd> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoCardPwd> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoCardPwd> ByPwd(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoCardPwd> queryable, string pwd)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Pwd == pwd);
    }

    #endregion

}
