using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entity.Entities;
using Core.Persistent.Entities;
using Core.Persistent.Extensions.DynamicFilterModel;

namespace Core.Persistent.Repository;

public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    // 查询
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    // 分页查询
    Task<(List<TEntity> Items, int TotalCount)> GetPagedAsync(
        int pageIndex, 
        int pageSize, 
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default);
    
    // 高级动态查询
    Task<Extensions.DynamicFilterModel.PagedResult<TEntity>> QueryAsync(PagedQueryRequest request, CancellationToken cancellationToken = default);
    Task<Extensions.DynamicFilterModel.PagedResult<TDestination>> QueryAsync<TDestination>(IConfigurationProvider configuration,PagedQueryRequest request, CancellationToken cancellationToken = default);
    
    // 计数
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    // 增删改
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    
    // 查询构建器
    IQueryable<TEntity> Query(bool includeDeleted = false);
}


