using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoModelExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoModel? GetByKey(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoModel> queryable, ushort modelid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoModel> dbSet)
            return dbSet.Find(modelid);

        return queryable.FirstOrDefault(q => q.Modelid == modelid);
    }

    public static async System.Threading.Tasks.ValueTask<Example.Entity.Data.Entities.GoModel?> GetByKeyAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoModel> queryable, ushort modelid, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<Example.Entity.Data.Entities.GoModel> dbSet)
            return await dbSet.FindAsync(new object[] { modelid }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Modelid == modelid, cancellationToken);
    }

    #endregion

}
