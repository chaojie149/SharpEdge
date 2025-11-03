using System.Linq.Expressions;
using Core.Entity.Entities;
using Core.Persistent.Entities;
using Core.Persistent.Repository;

namespace Core.Persistent.Caching;

public class CachedRepository<TEntity, TKey> : IRepository<TEntity, TKey> 
    where TEntity : BaseEntity<TKey>
{
    private readonly IRepository<TEntity, TKey> _innerRepository;
    private readonly IQueryCacheService _cacheService;
    private readonly string _cacheKeyPrefix;

    public CachedRepository(
        IRepository<TEntity, TKey> innerRepository,
        IQueryCacheService cacheService)
    {
        _innerRepository = innerRepository;
        _cacheService = cacheService;
        _cacheKeyPrefix = $"{typeof(TEntity).Name}:";
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var cacheKey = $"{_cacheKeyPrefix}Id:{id}";
        return await _cacheService.GetOrCreateAsync(
            cacheKey,
            () => _innerRepository.GetByIdAsync(id, cancellationToken),
            TimeSpan.FromMinutes(10));
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cacheKey = $"{_cacheKeyPrefix}All";
        return await _cacheService.GetOrCreateAsync(
            cacheKey,
            () => _innerRepository.GetAllAsync(cancellationToken),
            TimeSpan.FromMinutes(5)) ?? new List<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _innerRepository.AddAsync(entity, cancellationToken);
        _cacheService.RemoveByPattern(_cacheKeyPrefix);
        return result;
    }

    public void Update(TEntity entity)
    {
        _innerRepository.Update(entity);
        _cacheService.RemoveByPattern(_cacheKeyPrefix);
    }

    public void Delete(TEntity entity)
    {
        _innerRepository.Delete(entity);
        _cacheService.RemoveByPattern(_cacheKeyPrefix);
    }

    // 其他方法委托给内部仓储...
    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => _innerRepository.FirstOrDefaultAsync(predicate, cancellationToken);

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => _innerRepository.FindAsync(predicate, cancellationToken);

    public Task<(List<TEntity> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, CancellationToken cancellationToken = default)
        => _innerRepository.GetPagedAsync(pageIndex, pageSize, predicate, orderBy, cancellationToken);

    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
        => _innerRepository.CountAsync(predicate, cancellationToken);

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => _innerRepository.ExistsAsync(predicate, cancellationToken);

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _cacheService.RemoveByPattern(_cacheKeyPrefix);
        return _innerRepository.AddRangeAsync(entities, cancellationToken);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _cacheService.RemoveByPattern(_cacheKeyPrefix);
        _innerRepository.UpdateRange(entities);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _cacheService.RemoveByPattern(_cacheKeyPrefix);
        _innerRepository.DeleteRange(entities);
    }

    public IQueryable<TEntity> Query(bool includeDeleted = false)
        => _innerRepository.Query(includeDeleted);
}
