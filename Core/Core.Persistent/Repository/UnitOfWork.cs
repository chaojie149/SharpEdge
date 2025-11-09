using Core.Entity.Entities;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Persistent.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly ILogger<UnitOfWork>? _logger;
    private readonly Dictionary<Type, object> _repositories;
    private IDbContextTransaction? _transaction;
    private bool _disposed;

    public UnitOfWork(DbContext context, ILogger<UnitOfWork>? logger = null)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger;
        _repositories = new Dictionary<Type, object>();
    }

    
    
    public IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
    {
        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (IRepository<TEntity, TKey>)_repositories[type];
        }

        var repository = new Repository<TEntity, TKey>(_context);
        _repositories.Add(type, repository);

        return repository;
    }

   

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger?.LogError(ex, "Concurrency conflict occurred");
            throw;
        }
        catch (DbUpdateException ex)
        {
            _logger?.LogError(ex, "Database update failed");
            throw;
        }
    }

    public async Task<bool> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            // ✅ 添加执行策略包装
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            });
        
            _logger?.LogInformation("Transaction started");
            return true;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to start transaction");
            return false;
        }
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_transaction == null)
                throw new InvalidOperationException("No active transaction");

            await _context.SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
            _logger?.LogInformation("Transaction committed");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to commit transaction");
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(cancellationToken);
                _logger?.LogWarning("Transaction rolled back");
            }
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to rollback transaction");
            throw;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }
    public async Task<T> ExecuteInTransactionAsync<T>(
        Func<Task<T>> operation,
        CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
    
        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await operation();
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return result;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }

    public async Task ExecuteInTransactionAsync(
        Func<Task> operation,
        CancellationToken cancellationToken = default)
    {
        await ExecuteInTransactionAsync(async () =>
        {
            await operation();
            return 0;
        }, cancellationToken);
    }
    public DbContext GetDbContext()
    {
        return _context;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            _repositories.Clear();
        }
        _disposed = true;
    }
}
