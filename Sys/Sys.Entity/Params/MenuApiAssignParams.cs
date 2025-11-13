namespace Sys.Entity.Params;

/// <summary>
/// 菜单API关联参数
/// </summary>
public class MenuApiAssignParams
{
    /// <summary>
    /// 菜单ID
    /// </summary>
    public Guid MenuId { get; set; }

    /// <summary>
    /// API关联列表
    /// </summary>
    public List<ApiRelationItem> ApiRelations { get; set; } = new();
}
