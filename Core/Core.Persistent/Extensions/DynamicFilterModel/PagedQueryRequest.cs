namespace Core.Persistent.Extensions.DynamicFilterModel;

/// <summary>
/// 分页查询请求
/// </summary>
public class PagedQueryRequest
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public List<FilterRequest>? Filters { get; set; }
    public List<SortRequest>? Sorts { get; set; }
}
