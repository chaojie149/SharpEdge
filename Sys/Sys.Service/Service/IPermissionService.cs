using Core.Entity.Entities;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;

namespace Sys.Service.Service;

/// <summary>
/// 权限分配服务接口
/// </summary>
public interface IPermissionService
{
    // ──────────────── 用户角色分配 ────────────────
    
    /// <summary>
    /// 为用户分配角色
    /// </summary>
    Task<bool> AssignRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds);
    
    /// <summary>
    /// 移除用户的角色
    /// </summary>
    Task<bool> RemoveRolesFromUserAsync(Guid userId, IEnumerable<Guid> roleIds);
    
    /// <summary>
    /// 获取用户的所有角色
    /// </summary>
    Task<List<SysRoleDto>> GetUserRolesAsync(Guid userId);
    
    /// <summary>
    /// 获取拥有指定角色的所有用户
    /// </summary>
    Task<List<SysUserDto>> GetRoleUsersAsync(Guid roleId);
    
    // ──────────────── 角色权限分配 ────────────────
    
    /// <summary>
    /// 为角色分配权限（菜单权限和API权限）
    /// </summary>
    Task<bool> AssignPermissionsToRoleAsync(RolePermissionAssignParams assignParams);
    
    /// <summary>
    /// 移除角色的权限
    /// </summary>
    Task<bool> RemovePermissionsFromRoleAsync(Guid roleId, IEnumerable<Guid> permissionIds, string permissionType);
    
    /// <summary>
    /// 获取角色的所有权限（分类返回）
    /// </summary>
    Task<RolePermissionsDto> GetRolePermissionsAsync(Guid roleId);
    
    /// <summary>
    /// 获取拥有指定权限的所有角色
    /// </summary>
    Task<List<SysRoleDto>> GetPermissionRolesAsync(Guid permissionId, string permissionType);
    
    // ──────────────── 用户权限查询（合并） ────────────────
    
    /// <summary>
    /// 获取用户的所有权限（合并所有角色的权限）
    /// </summary>
    Task<UserPermissionsDto> GetUserPermissionsAsync(Guid userId);
    
    /// <summary>
    /// 获取用户的所有菜单权限树（合并去重）
    /// </summary>
    Task<List<TreeNode<SysMenuPermission, Guid>>> GetUserMenuTreeAsync(Guid userId, int? maxDepth = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取用户的所有API权限（合并去重）
    /// </summary>
    Task<List<SysApiDto>> GetUserApisAsync(Guid userId);
    
    /// <summary>
    /// 验证用户是否拥有指定权限
    /// </summary>
    Task<bool> CheckUserPermissionAsync(Guid userId, string permissionCode);
    
    /// <summary>
    /// 验证用户是否拥有指定角色
    /// </summary>
    Task<bool> CheckUserRoleAsync(Guid userId, string roleCode);
}