namespace Sys.Entity.Params;

/// <summary>
/// 角色权限分配参数
/// </summary>
public class RolePermissionAssignParams
{
    /// <summary>
    /// 角色ID
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// 菜单权限ID列表
    /// </summary>
    public IEnumerable<Guid>? MenuPermissionIds { get; set; }

    /// <summary>
    /// API权限ID列表
    /// </summary>
    public IEnumerable<Guid>? ApiPermissionIds { get; set; }
}