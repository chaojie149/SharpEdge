using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Core.Entity.Entities;
using Core.Persistent.Entities;
using Core.Persistent.Extensions;
using Core.Persistent.Extensions.DynamicFilterModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Core.Persistent.Repository;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> Query(bool includeDeleted = false)
    {
        var query = _dbSet.AsQueryable();
        
        if (!includeDeleted && typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
        {
            return query.IgnoreQueryFilters().Where(e => !((ISoftDelete)e).IsDeleted);
        }
        
        return includeDeleted ? query.IgnoreQueryFilters() : query;
    }

    public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id! }, cancellationToken);
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate, 
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<List<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>> predicate, 
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual async Task<(List<TEntity> Items, int TotalCount)> GetPagedAsync(
        int pageIndex, 
        int pageSize, 
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (predicate != null)
            query = query.Where(predicate);

        var totalCount = await query.CountAsync(cancellationToken);

        if (orderBy != null)
            query = orderBy(query);

        var items = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

    /// <summary>
    /// 高级动态查询（支持动态过滤、排序、分页）
    /// </summary>
    public virtual async Task<Extensions.DynamicFilterModel.PagedResult<TEntity>> QueryAsync(
        PagedQueryRequest request, 
        CancellationToken cancellationToken = default)
    {
        var query = Query();

        // 应用过滤
        query = query.ApplyFilters(request.Filters);

        // 获取总数
        var totalCount = await query.CountAsync(cancellationToken);

        // 应用排序
        query = query.ApplySorts(request.Sorts);

        // 应用分页
        query = query.ApplyPaging(request.PageIndex, request.PageSize);

        // 执行查询
        var items = await query.ToListAsync(cancellationToken);

        return new Extensions.DynamicFilterModel.PagedResult<TEntity>
        {
            Items = items,
            TotalCount = totalCount,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
    }

    public async Task<Extensions.DynamicFilterModel.PagedResult<TDestination>> QueryAsync<TDestination>(IConfigurationProvider configuration, PagedQueryRequest request,
        CancellationToken cancellationToken = default)
    {  // 基础查询
        var query = Query();

        // 应用动态过滤（来自 Core.Persistent.Extensions.DynamicFilterModel）
        query = query.ApplyFilters(request.Filters);

        // 获取总数
        var totalCount = await query.CountAsync(cancellationToken);

        // 应用排序
        query = query.ApplySorts(request.Sorts);

        // 投影到目标类型（例如 SysUserDto）
        var projectedQuery = query.ProjectTo<TDestination>(configuration);

        // 应用分页
        projectedQuery = projectedQuery.ApplyPaging(request.PageIndex, request.PageSize);

        // 执行查询
        var items = await projectedQuery.ToListAsync(cancellationToken);

        // 返回分页结果
        return new Extensions.DynamicFilterModel.PagedResult<TDestination>
        {
            Items = items,
            TotalCount = totalCount,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };throw new NotImplementedException();
    }


    public virtual async Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate = null, 
        CancellationToken cancellationToken = default)
    {
        return predicate == null 
            ? await _dbSet.CountAsync(cancellationToken)
            : await _dbSet.CountAsync(predicate, cancellationToken);
    }

    public virtual async Task<bool> ExistsAsync(
        Expression<Func<TEntity, bool>> predicate, 
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}