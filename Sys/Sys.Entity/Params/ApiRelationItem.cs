namespace Sys.Entity.Params;

public class ApiRelationItem
{
    /// <summary>
    /// API ID
    /// </summary>
    public Guid ApiId { get; set; }

    /// <summary>
    /// 是否必需
    /// </summary>
    public bool Required { get; set; } = true;

    /// <summary>
    /// 排序
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}