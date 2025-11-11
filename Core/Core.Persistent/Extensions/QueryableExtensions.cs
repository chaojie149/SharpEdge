using System;
using System.Collections;
using System.Linq;
using Core.Persistent.Extensions.DynamicFilterModel;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistent.Extensions;

public static class QueryableExtensions
{
    
  /// <summary>
    /// 应用动态过滤
    /// </summary>
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, List<FilterRequest>? filters)
    {
        if (filters == null || !filters.Any())
            return query;

        Expression<Func<T, bool>>? combinedPredicate = null;

        foreach (var filter in filters)
        {
            var predicate = BuildPredicate<T>(filter);
            
            if (predicate == null)
                continue;

            if (combinedPredicate == null)
            {
                combinedPredicate = predicate;
            }
            else
            {
                combinedPredicate = filter.Logic == LogicalOperator.And
                    ? CombinePredicates(combinedPredicate, predicate, Expression.AndAlso)
                    : CombinePredicates(combinedPredicate, predicate, Expression.OrElse);
            }
        }

        return combinedPredicate != null ? query.Where(combinedPredicate) : query;
    }

    /// <summary>
    /// 应用动态排序
    /// </summary>
    public static IQueryable<T> ApplySorts<T>(this IQueryable<T> query, List<SortRequest>? sorts)
    {
        if (sorts == null || !sorts.Any())
            return query;

        IOrderedQueryable<T>? orderedQuery = null;

        foreach (var sort in sorts)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = GetPropertyExpression(parameter, sort.Field);

            if (property == null)
                continue;

            var lambda = Expression.Lambda(property, parameter);
            var methodName = orderedQuery == null
                ? (sort.Direction == SortDirection.Ascending ? "OrderBy" : "OrderByDescending")
                : (sort.Direction == SortDirection.Ascending ? "ThenBy" : "ThenByDescending");

            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                orderedQuery?.Expression ?? query.Expression,
                Expression.Quote(lambda));

            orderedQuery = (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(resultExpression);
        }

        return orderedQuery ?? query;
    }

    /// <summary>
    /// 应用分页
    /// </summary>
    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageIndex, int pageSize)
    {
        if (pageIndex < 1) pageIndex = 1;
        if (pageSize < 1) pageSize = 10;

        return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }

    /// <summary>
    /// 构建过滤表达式
    /// </summary>
    private static Expression<Func<T, bool>>? BuildPredicate<T>(FilterRequest filter)
    {
        try
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = GetPropertyExpression(parameter, filter.Field);

            if (property == null)
                return null;

            Expression? body = null;

            switch (filter.Operator)
            {
                case FilterOperator.Equal:
                    body = Expression.Equal(property, Expression.Constant(Convert.ChangeType(filter.Value, property.Type)));
                    break;

                case FilterOperator.NotEqual:
                    body = Expression.NotEqual(property, Expression.Constant(Convert.ChangeType(filter.Value, property.Type)));
                    break;

                case FilterOperator.GreaterThan:
                    body = Expression.GreaterThan(property, Expression.Constant(Convert.ChangeType(filter.Value, property.Type)));
                    break;

                case FilterOperator.GreaterThanOrEqual:
                    body = Expression.GreaterThanOrEqual(property, Expression.Constant(Convert.ChangeType(filter.Value, property.Type)));
                    break;

                case FilterOperator.LessThan:
                    body = Expression.LessThan(property, Expression.Constant(Convert.ChangeType(filter.Value, property.Type)));
                    break;

                case FilterOperator.LessThanOrEqual:
                    body = Expression.LessThanOrEqual(property, Expression.Constant(Convert.ChangeType(filter.Value, property.Type)));
                    break;

                case FilterOperator.Contains:
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    body = Expression.Call(property, containsMethod!, Expression.Constant(filter.Value));
                    break;

                case FilterOperator.StartsWith:
                    var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                    body = Expression.Call(property, startsWithMethod!, Expression.Constant(filter.Value));
                    break;

                case FilterOperator.EndsWith:
                    var endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                    body = Expression.Call(property, endsWithMethod!, Expression.Constant(filter.Value));
                    break;

                case FilterOperator.In:
                    if (filter.Value is IEnumerable enumerable)
                    {
                        var values = enumerable.Cast<object>().ToList();
                        var containsMethodForList = typeof(Enumerable).GetMethods()
                            .First(m => m.Name == "Contains" && m.GetParameters().Length == 2)
                            .MakeGenericMethod(property.Type);
                        body = Expression.Call(containsMethodForList, Expression.Constant(values.Select(v => Convert.ChangeType(v, property.Type)).ToList()), property);
                    }
                    break;

                case FilterOperator.NotIn:
                    if (filter.Value is IEnumerable enumerable2)
                    {
                        var values = enumerable2.Cast<object>().ToList();
                        var containsMethodForList = typeof(Enumerable).GetMethods()
                            .First(m => m.Name == "Contains" && m.GetParameters().Length == 2)
                            .MakeGenericMethod(property.Type);
                        var inExpression = Expression.Call(containsMethodForList, Expression.Constant(values.Select(v => Convert.ChangeType(v, property.Type)).ToList()), property);
                        body = Expression.Not(inExpression);
                    }
                    break;

                case FilterOperator.IsNull:
                    body = Expression.Equal(property, Expression.Constant(null, property.Type));
                    break;

                case FilterOperator.IsNotNull:
                    body = Expression.NotEqual(property, Expression.Constant(null, property.Type));
                    break;
            }

            return body != null ? Expression.Lambda<Func<T, bool>>(body, parameter) : null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// 获取属性表达式（支持嵌套属性，如 "User.Name"）
    /// </summary>
    private static Expression? GetPropertyExpression(Expression parameter, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
            return null;

        var properties = propertyName.Split('.');
        Expression? property = parameter;

        foreach (var prop in properties)
        {
            var propertyInfo = property!.Type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
                return null;

            property = Expression.Property(property, propertyInfo);
        }

        return property;
    }

    /// <summary>
    /// 组合两个表达式
    /// </summary>
    private static Expression<Func<T, bool>> CombinePredicates<T>(
        Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right,
        Func<Expression, Expression, BinaryExpression> combiner)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var leftBody = new ParameterReplacer(parameter).Visit(left.Body);
        var rightBody = new ParameterReplacer(parameter).Visit(right.Body);
        var body = combiner(leftBody!, rightBody!);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    /// <summary>
    /// 参数替换访问器
    /// </summary>
    private class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;

        public ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }
    }
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
