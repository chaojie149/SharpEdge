namespace Sys.Entity.Dtos;

/// <summary>
/// 角色权限DTO（包含菜单权限和API权限）
/// </summary>
public class RolePermissionsDto
{
    public Guid RoleId { get; set; }
    public List<SysMenuPermissionDto> MenuPermissions { get; set; } = new();
    public List<SysApiDto> ApiPermissions { get; set; } = new();
}