using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoWxchCfgExtensions
{
    #region Generated Extensions
    public static Example.Entity.Data.Entities.GoWxchCfg? GetByCfgId(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoWxchCfg> queryable, uint cfgId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.FirstOrDefault(q => q.CfgId == cfgId);
    }

    public static async System.Threading.Tasks.Task<Example.Entity.Data.Entities.GoWxchCfg?> GetByCfgIdAsync(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoWxchCfg> queryable, uint cfgId, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return await queryable.FirstOrDefaultAsync(q => q.CfgId == cfgId, cancellationToken);
    }

    #endregion

}
