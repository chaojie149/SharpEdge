using Core.Persistent.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace Core.Persistent.Interceptors;

public class AuditInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public AuditInterceptor(IHttpContextAccessor? httpContextAccessor = null)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        UpdateAuditFields(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateAuditFields(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateAuditFields(DbContext? context)
    {
        if (context == null) return;

        var currentUser = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "System";
        var utcNow = DateTime.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    Log.Debug($"Adding {entry.Entity.GetType().Name}");

                    entry.Entity.CreatedTime = utcNow;
                    entry.Entity.CreatedBy = currentUser;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifyTime = utcNow;
                    entry.Entity.ModifyBy = currentUser;
                    break;
            }
        }
        
        //TODO 软删除未启用
        // foreach (var entry in context.ChangeTracker.Entries<ISoftDelete>())
        // {
        //     if (entry.State == EntityState.Deleted)
        //     {
        //         entry.State = EntityState.Modified;
        //         entry.Entity.IsDeleted = true;
        //         entry.Entity.DeletedAt = utcNow;
        //         entry.Entity.DeletedBy = currentUser;
        //     }
        // }
    }
}