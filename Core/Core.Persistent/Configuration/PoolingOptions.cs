namespace Core.Persistent.Configuration;

public class PoolingOptions
{
    public int MaxPoolSize { get; set; } = 100;
    public int MinPoolSize { get; set; } = 5;
}