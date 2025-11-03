using System.Linq.Expressions;
using Core.Persistent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Persistent.Context;

public abstract class BaseDbContext : DbContext
{
    private readonly ILogger<BaseDbContext>? _logger;

    protected BaseDbContext(DbContextOptions options, ILogger<BaseDbContext>? logger = null) 
        : base(options)
    {
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //TODO 软删除过滤器
        // // 全局查询过滤器 - 软删除
        // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        // {
        //     if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
        //     {
        //         var parameter = Expression.Parameter(entityType.ClrType, "e");
        //         var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
        //         var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);
        //         
        //         modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        //     }
        // }

        // 应用所有配置
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            _logger?.LogInformation("Successfully saved {Count} changes to database", result);
            return result;
        }
        catch (DbUpdateException ex)
        {
            _logger?.LogError(ex, "Database update error occurred");
            throw;
        }
    }
}