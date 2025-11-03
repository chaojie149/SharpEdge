namespace Core.Persistent.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    
    public string DefaultConnection { get; set; } = string.Empty;
    public Dictionary<string, DataSourceOptions> DataSources { get; set; } = new();
    public bool EnableSensitiveDataLogging { get; set; } = false;
    public bool EnableDetailedErrors { get; set; } = false;
    public int CommandTimeout { get; set; } = 30;
    public int MaxRetryCount { get; set; } = 3;
    public int MaxRetryDelay { get; set; } = 30;
    public PoolingOptions Pooling { get; set; } = new();
}
