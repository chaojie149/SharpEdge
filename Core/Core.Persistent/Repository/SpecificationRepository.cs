using Core.Entity.Entities;
using Core.Persistent.Entities;
using Core.Persistent.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistent.Repository;

public class SpecificationRepository<TEntity, TKey> : Repository<TEntity, TKey>, ISpecificationRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
{
    public SpecificationRepository(DbContext context) : base(context)
    {
    }

    public async Task<TEntity?> GetBySpecAsync(
        ISpecification<TEntity> spec,
        CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(spec);
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TEntity>> ListAsync(
        ISpecification<TEntity> spec,
        CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(spec);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(
        ISpecification<TEntity> spec,
        CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(spec);
        return await query.CountAsync(cancellationToken);
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
    {
        return SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), spec);
    }
}