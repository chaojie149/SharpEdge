using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoArticleExtensions
{
    #region Generated Extensions
    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoArticle> ByCateid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoArticle> queryable, string cateid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Cateid == cateid);
    }

    public static Example.Entity.Data.Entities.GoArticle? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoArticle> queryable, uint id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoArticle> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoArticle?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoArticle> queryable, uint id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoArticle> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    #endregion

}
