namespace Sys.Entity.Dtos;

/// <summary>
/// 用户权限DTO（合并所有角色的权限）
/// </summary>
public class UserPermissionsDto
{
    public Guid UserId { get; set; }
    public List<SysRoleDto> Roles { get; set; } = new();
    public List<SysMenuPermissionDto> MenuPermissions { get; set; } = new();
    public List<SysApiDto> ApiPermissions { get; set; } = new();
}