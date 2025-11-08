using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistent.Extensions;

public static class QueryableExtensions
{
    // 条件查询
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> query,
        bool condition,
        Expression<Func<T, bool>> predicate)
    {
        return condition ? query.Where(predicate) : query;
    }

    // 分页扩展
    public static IQueryable<T> Paginate<T>(
        this IQueryable<T> query,
        int pageIndex,
        int pageSize)
    {
        return query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
    }

    // 包含多个导航属性
    public static IQueryable<T> IncludeMultiple<T>(
        this IQueryable<T> query,
        params Expression<Func<T, object>>[] includes) where T : class
    {
        return includes.Aggregate(query, (current, include) => current.Include(include));
    }

    // 软删除过滤
    public static IQueryable<T> IncludeDeleted<T>(this IQueryable<T> query) where T : class, ISoftDelete
    {
        return query.IgnoreQueryFilters();
    }

    // 审计信息查询
    public static IQueryable<T> CreatedBy<T>(
        this IQueryable<T> query,
        string createdBy) where T : class, IAuditableEntity
    {
        return query.Where(e => e.CreatedBy == createdBy);
    }

    public static IQueryable<T> CreatedBetween<T>(
        this IQueryable<T> query,
        DateTime startDate,
        DateTime endDate) where T : class, IAuditableEntity
    {
        return query.Where(e => e.CreatedTime >= startDate && e.CreatedTime <= endDate);
    }
}
