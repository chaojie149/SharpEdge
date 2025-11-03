using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberRechangeExtensions
{
    #region Generated Extensions
    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRechange> ByType(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRechange> queryable, bool? type)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Type == type || (type == null && q.Type == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRechange> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberRechange> queryable, uint uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    #endregion

}
