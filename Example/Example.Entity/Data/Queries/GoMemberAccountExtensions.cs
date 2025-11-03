using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Queries;

public static partial class GoMemberAccountExtensions
{
    #region Generated Extensions
    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberAccount> ByType(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberAccount> queryable, bool? type)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.Type == type || (type == null && q.Type == null)));
    }

    public static System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberAccount> ByUid(this System.Linq.IQueryable<Example.Entity.Data.Entities.GoMemberAccount> queryable, uint uid)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.Uid == uid);
    }

    #endregion

}
