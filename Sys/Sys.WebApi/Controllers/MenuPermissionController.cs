using Core.Persistent.Extensions.DynamicFilterModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sys.Entity.Params;
using Sys.Service.Service;

namespace Sys.WebApi.Controllers;

/// <summary>
/// 菜单权限控制器（支持增删改查与树形结构操作）
/// </summary>
[Tags("System Management / Menu Permission Management")]
[ApiController]
[Route("api/[controller]")]
public class MenuPermissionController : ControllerBase
{
    private readonly IMenuPermissionService _menuService;
    private readonly ILogger<MenuPermissionController> _logger;

    public MenuPermissionController(IMenuPermissionService menuService, ILogger<MenuPermissionController> logger)
    {
        _menuService = menuService;
        _logger = logger;
    }

    // ──────────────── CRUD 接口 ────────────────

    [EndpointSummary("分页查询菜单权限")]
    [EndpointDescription("支持条件筛选、分页、排序，返回菜单权限分页结果。")]
    [HttpPost("Query")]
    public async Task<IActionResult> Query([FromBody] PagedQueryRequest queryRequest)
    {
        var result = await _menuService.QueryAsync(queryRequest);
        return Ok(result);
    }

    [EndpointSummary("获取菜单详情")]
    [EndpointDescription("根据菜单ID获取单个菜单的详细信息。")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _menuService.GetAsync(id);
        if (result == null)
            return NotFound(new { message = "菜单不存在" });
        return Ok(result);
    }

    [EndpointSummary("添加菜单节点")]
    [EndpointDescription("创建一个新的菜单或按钮节点，自动计算层级。")]
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] SysMenuPermissionAddOrEditParams addParams)
    {
        var success = await _menuService.AddAsync(addParams);
        return Ok(new { success });
    }

    [EndpointSummary("更新菜单节点")]
    [EndpointDescription("根据ID修改菜单信息，自动维护层级与路径。")]
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] SysMenuPermissionAddOrEditParams updateParams)
    {
        var success = await _menuService.UpdateAsync(updateParams);
        return Ok(new { success });
    }

    [EndpointSummary("删除菜单节点（含后代）")]
    [EndpointDescription("根据ID删除菜单节点及其所有子节点。")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _menuService.DeleteAsync(id);
        return Ok(new { success });
    }

    [EndpointSummary("批量删除菜单节点")]
    [EndpointDescription("根据多个菜单ID批量删除菜单节点。")]
    [HttpPost("BatchDelete")]
    public async Task<IActionResult> BatchDelete([FromBody] IEnumerable<Guid> ids)
    {
        var count = await _menuService.BatchDeleteAsync(ids);
        return Ok(new { deletedCount = count });
    }

    // ──────────────── 树形结构接口 ────────────────

    [EndpointSummary("获取所有根节点")]
    [EndpointDescription("返回顶层菜单节点列表（ParentId 为空或 Guid.Empty 的节点）。")]
    [HttpGet("roots")]
    public async Task<IActionResult> GetRoots(CancellationToken cancellationToken)
    {
        var result = await _menuService.GetRootNodesAsync(cancellationToken);
        return Ok(result);
    }

    [EndpointSummary("获取指定节点的子节点")]
    [EndpointDescription("根据父节点ID获取直接子节点列表。")]
    [HttpGet("{parentId:guid}/children")]
    public async Task<IActionResult> GetChildren(Guid parentId, CancellationToken cancellationToken)
    {
        var result = await _menuService.GetChildrenAsync(parentId, cancellationToken);
        return Ok(result);
    }

    [EndpointSummary("获取完整树结构（嵌套）")]
    [EndpointDescription("返回完整的树形菜单结构，可选 rootId 和 maxDepth 参数。")]
    [HttpGet("tree")]
    public async Task<IActionResult> GetTree([FromQuery] Guid? rootId = null, [FromQuery] int? maxDepth = null, CancellationToken cancellationToken = default)
    {
        var result = await _menuService.GetTreeAsync(rootId, maxDepth, cancellationToken);
        return Ok(result);
    }

    [EndpointSummary("获取树形结构（扁平列表）")]
    [EndpointDescription("返回带层级信息的菜单列表，可选 rootId 和 maxDepth 参数。")]
    [HttpGet("tree-flat")]
    public async Task<IActionResult> GetTreeFlat([FromQuery] Guid? rootId = null, [FromQuery] int? maxDepth = null, CancellationToken cancellationToken = default)
    {
        var result = await _menuService.GetTreeFlatAsync(rootId, maxDepth, cancellationToken);
        return Ok(result);
    }

    [EndpointSummary("获取指定节点的祖先节点")]
    [EndpointDescription("递归向上查找指定节点的所有父级节点。")]
    [HttpGet("{id:guid}/ancestors")]
    public async Task<IActionResult> GetAncestors(Guid id, CancellationToken cancellationToken)
    {
        var result = await _menuService.GetAncestorsAsync(id, cancellationToken);
        return Ok(result);
    }

    [EndpointSummary("获取指定节点的所有后代节点")]
    [EndpointDescription("递归向下查找指定节点的所有子孙节点。")]
    [HttpGet("{id:guid}/descendants")]
    public async Task<IActionResult> GetDescendants(Guid id, CancellationToken cancellationToken)
    {
        var result = await _menuService.GetDescendantsAsync(id, cancellationToken);
        return Ok(result);
    }

    [EndpointSummary("移动菜单节点")]
    [EndpointDescription("将指定菜单节点移动到新的父节点下。")]
    [HttpPost("{id:guid}/move")]
    public async Task<IActionResult> MoveNode(Guid id, [FromBody] Guid? newParentId, CancellationToken cancellationToken)
    {
        await _menuService.MoveNodeAsync(id, newParentId, cancellationToken);
        return Ok(new { success = true, message = "节点移动成功" });
    }

    [EndpointSummary("判断是否存在子节点")]
    [EndpointDescription("检查指定菜单节点是否包含子节点，用于前端懒加载。")]
    [HttpGet("{id:guid}/has-children")]
    public async Task<IActionResult> HasChildren(Guid id, CancellationToken cancellationToken)
    {
        var hasChildren = await _menuService.HasChildrenAsync(id, cancellationToken);
        return Ok(new { hasChildren });
    }
}
