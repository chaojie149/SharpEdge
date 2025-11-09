using Core.Entity.Entities;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Persistent.Repository;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task<T> ExecuteInTransactionAsync<T>(
        Func<Task<T>> operation, 
        CancellationToken cancellationToken = default);
    
    Task ExecuteInTransactionAsync(
        Func<Task> operation, 
        CancellationToken cancellationToken = default);
    
    DbContext GetDbContext();
}