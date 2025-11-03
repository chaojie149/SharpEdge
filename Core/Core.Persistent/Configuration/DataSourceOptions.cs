using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Persistent.Configuration;

public class DataSourceOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public DatabaseProvider Provider { get; set; } = DatabaseProvider.MySQL;
    public bool EnableLogging { get; set; } = true;
    public int? CommandTimeout { get; set; }
}