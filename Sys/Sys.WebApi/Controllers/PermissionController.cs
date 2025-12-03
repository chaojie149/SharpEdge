using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sys.Entity.Params;
using Sys.Service.Service;

namespace Sys.WebApi.Controllers;

/// <summary>
/// 权限分配控制器
/// </summary>
[Tags("System Management / Permission Assignment")]
[ApiController]
[Route("[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;
    private readonly IMenuPermissionService _menuPermissionService;
    private readonly ILogger<PermissionController> _logger;

    public PermissionController(IPermissionService permissionService, IMenuPermissionService menuPermissionService, ILogger<PermissionController> logger)
    {
        _permissionService = permissionService;
        _menuPermissionService = menuPermissionService;
        _logger = logger;
    }

    // ──────────────── 用户角色管理 ────────────────

    [EndpointSummary("为用户分配角色")]
    [EndpointDescription("为指定用户分配一个或多个角色，自动去重。")]
    [HttpPost("user/{userId:guid}/roles")]
    public async Task<IActionResult> AssignRolesToUser(Guid userId,  IEnumerable<Guid> roleIds)
    {
        var success = await _permissionService.AssignRolesToUserAsync(userId, roleIds);
        return Ok(new { success, message = "角色分配成功" });
    }

    [EndpointSummary("移除用户的角色")]
    [EndpointDescription("从指定用户移除一个或多个角色。")]
    [HttpDelete("user/{userId:guid}/roles")]
    public async Task<IActionResult> RemoveRolesFromUser(Guid userId, [FromBody] IEnumerable<Guid> roleIds)
    {
        var success = await _permissionService.RemoveRolesFromUserAsync(userId, roleIds);
        return Ok(new { success, message = "角色移除成功" });
    }

    [EndpointSummary("获取用户的所有角色")]
    [EndpointDescription("查询指定用户拥有的所有角色列表。")]
    [HttpGet("user/{userId:guid}/roles")]
    public async Task<IActionResult> GetUserRoles(Guid userId)
    {
        var result = await _permissionService.GetUserRolesAsync(userId);
        return Ok(result);
    }

    [EndpointSummary("获取拥有指定角色的所有用户")]
    [EndpointDescription("查询拥有指定角色的用户列表。")]
    [HttpGet("role/{roleId:guid}/users")]
    public async Task<IActionResult> GetRoleUsers(Guid roleId)
    {
        var result = await _permissionService.GetRoleUsersAsync(roleId);
        return Ok(result);
    }

    // ──────────────── 角色权限管理 ────────────────

    [EndpointSummary("为角色分配权限")]
    [EndpointDescription("为指定角色分配菜单权限和/或API权限，自动去重。")]
    [HttpPost("role/permissions")]
    public async Task<IActionResult> AssignPermissionsToRole([FromBody] RolePermissionAssignParams assignParams)
    {
        var success = await _permissionService.AssignPermissionsToRoleAsync(assignParams);
        return Ok(new { success, message = "权限分配成功" });
    }

    [EndpointSummary("移除角色的权限")]
    [EndpointDescription("从指定角色移除指定类型的权限。")]
    [HttpDelete("role/{roleId:guid}/permissions")]
    public async Task<IActionResult> RemovePermissionsFromRole(
        Guid roleId, 
        [FromQuery] string permissionType, 
        [FromBody] IEnumerable<Guid> permissionIds)
    {
        var success = await _permissionService.RemovePermissionsFromRoleAsync(roleId, permissionIds, permissionType);
        return Ok(new { success, message = "权限移除成功" });
    }

    [EndpointSummary("获取角色的所有权限")]
    [EndpointDescription("查询指定角色拥有的所有菜单权限和API权限。")]
    [HttpGet("role/{roleId:guid}/permissions")]
    public async Task<IActionResult> GetRolePermissions(Guid roleId)
    {
        var result = await _permissionService.GetRolePermissionsAsync(roleId);
        return Ok(result);
    }

    [EndpointSummary("获取拥有指定权限的所有角色")]
    [EndpointDescription("查询拥有指定权限的角色列表（需指定权限类型：menu/api）。")]
    [HttpGet("permission/{permissionId:guid}/roles")]
    public async Task<IActionResult> GetPermissionRoles(Guid permissionId, [FromQuery] string permissionType)
    {
        var result = await _permissionService.GetPermissionRolesAsync(permissionId, permissionType);
        return Ok(result);
    }

    // ──────────────── 用户权限查询（合并） ────────────────

    [EndpointSummary("获取用户的所有权限")]
    [EndpointDescription("查询用户通过所有角色获得的全部权限（合并去重），包括角色、菜单权限和API权限。")]
    [HttpGet("user/{userId:guid}/permissions")]
    public async Task<IActionResult> GetUserPermissions(Guid userId)
    {
        var result = await _permissionService.GetUserPermissionsAsync(userId);
        return Ok(result);
    }

    [EndpointSummary("获取用户的菜单权限树")]
    [EndpointDescription("查询用户的菜单权限并构建树形结构（合并所有角色的菜单权限并去重）。")]
    [HttpGet("user/{userId:guid}/menu-tree")]
    public async Task<IActionResult> GetUserMenuTree(
        Guid userId, 
        [FromQuery] int? maxDepth = null, 
        CancellationToken cancellationToken = default)
    {
        var result = await _permissionService.GetUserMenuTreeAsync(userId, maxDepth, cancellationToken);
        return Ok(result);
    }


    [EndpointSummary("验证用户权限")]
    [EndpointDescription("检查用户是否拥有指定的权限码（PermissionCode）。")]
    [HttpGet("user/{userId:guid}/check-permission")]
    public async Task<IActionResult> CheckUserPermission(Guid userId, [FromQuery] string permissionCode)
    {
        var hasPermission = await _permissionService.CheckUserPermissionAsync(userId, permissionCode);
        return Ok(new { hasPermission });
    }

    [EndpointSummary("验证用户角色")]
    [EndpointDescription("检查用户是否拥有指定的角色码（RoleCode）。")]
    [HttpGet("user/{userId:guid}/check-role")]
    public async Task<IActionResult> CheckUserRole(Guid userId, [FromQuery] string roleCode)
    {
        var hasRole = await _permissionService.CheckUserRoleAsync(userId, roleCode);
        return Ok(new { hasRole });
    }
    
    // 在 MenuPermissionController 类中添加以下接口

}