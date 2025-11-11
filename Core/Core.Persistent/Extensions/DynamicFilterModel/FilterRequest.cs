namespace Core.Persistent.Extensions.DynamicFilterModel;

/// <summary>
/// 过滤请求
/// </summary>
public class FilterRequest
{
    /// <summary>
    /// 字段名
    /// </summary>
    public string Field { get; set; } = string.Empty;
    
    /// <summary>
    /// 操作符
    /// </summary>
    public FilterOperator Operator { get; set; }
    
    /// <summary>
    /// 值
    /// </summary>
    public object? Value { get; set; }
    
    /// <summary>
    /// 逻辑运算符（用于多个过滤条件）
    /// </summary>
    public LogicalOperator Logic { get; set; } = LogicalOperator.And;
}