

// ============================================
// 9. Context/DbContextFactory.cs
// ============================================

using Core.Persistent.Configuration;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.DependencyInjection;

public interface IDbContextFactory
{
    DbContext CreateDbContext(string dataSourceName);
}

