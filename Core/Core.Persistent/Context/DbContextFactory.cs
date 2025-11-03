using Core.Persistent.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistent.Context;

public class DbContextFactory : IDbContextFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DatabaseOptions _databaseOptions;

    public DbContextFactory(IServiceProvider serviceProvider, DatabaseOptions databaseOptions)
    {
        _serviceProvider = serviceProvider;
        _databaseOptions = databaseOptions;
    }

    public DbContext CreateDbContext(string dataSourceName)
    {
        if (!_databaseOptions.DataSources.ContainsKey(dataSourceName))
        {
            throw new ArgumentException($"Data source '{dataSourceName}' not found", nameof(dataSourceName));
        }

        var scope = _serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<DbContext>();
    }
}