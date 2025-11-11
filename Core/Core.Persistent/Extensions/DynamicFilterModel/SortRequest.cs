namespace Core.Persistent.Extensions.DynamicFilterModel;

/// <summary>
/// 排序请求
/// </summary>
public class SortRequest
{
    /// <summary>
    /// 字段名
    /// </summary>
    public string Field { get; set; } = string.Empty;
    
    /// <summary>
    /// 排序方向
    /// </summary>
    public SortDirection Direction { get; set; } = SortDirection.Ascending;
}