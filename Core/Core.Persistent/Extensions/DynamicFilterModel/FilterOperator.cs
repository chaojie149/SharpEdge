namespace Core.Persistent.Extensions.DynamicFilterModel;

/// <summary>
/// 过滤操作符
/// </summary>
public enum FilterOperator
{
    Equal,              // 等于
    NotEqual,           // 不等于
    GreaterThan,        // 大于
    GreaterThanOrEqual, // 大于等于
    LessThan,           // 小于
    LessThanOrEqual,    // 小于等于
    Contains,           // 包含（字符串）
    StartsWith,         // 开始于（字符串）
    EndsWith,           // 结束于（字符串）
    In,                 // 在集合中
    NotIn,              // 不在集合中
    IsNull,             // 为空
    IsNotNull           // 不为空
}