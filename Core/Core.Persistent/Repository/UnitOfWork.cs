using Core.Entity.Entities;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

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
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
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
