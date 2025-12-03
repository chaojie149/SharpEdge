using Core.Persistent.Extensions.DynamicFilterModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Entity.Params;
using Sys.Service.Service;

namespace Sys.WebApi.Controllers;

[Tags("System Management / Role Management")]
[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [EndpointSummary("分页查询角色列表")]
    [EndpointDescription("支持条件查询和分页，返回分页结果")]
    [HttpPost("Query")]
    public async Task<IActionResult> QueryRoles([FromBody] PagedQueryRequest queryRequest)
    {
        var result = await _roleService.QueryAsync(queryRequest);
        return Ok(result);
    }

    [EndpointSummary("获取角色详情")]
    [EndpointDescription("根据角色ID获取详细信息")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRole(Guid id)
    {
        var result = await _roleService.GetRoleAsync(id);
        return Ok(result);
    }
    
    [EndpointSummary("获取全部角色")]
    [EndpointDescription("获取全部角色")]
    [HttpGet("All")]
    public async Task<IActionResult> GetAllRole(Guid id)
    {
        var result = await _roleService.GetAllRoleAsync();
        return Ok(result);
    }

    [EndpointSummary("添加角色")]
    [EndpointDescription("创建一个新的角色")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddRole([FromBody] SysRoleAddOrEditParams roleParams)
    {
        var result = await _roleService.AddRoleAsync(roleParams);
        return Ok( new {Message = result ? "添加成功":"添加失败"});
    }

    [EndpointSummary("更新角色信息")]
    [EndpointDescription("根据ID更新角色基础信息")]
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateRole([FromBody] SysRoleAddOrEditParams roleParams)
    {
        var result = await _roleService.UpdateRoleAsync(roleParams);
        return Ok( new {Message = result ? "更新成功":"更新失败"});
    }

    [EndpointSummary("删除角色")]
    [EndpointDescription("根据角色ID删除对应角色")]
    [HttpDelete("DeleteRole/{id:guid}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var result = await _roleService.DeleteRoleAsync(id);
        return Ok( new {Message = result ? "删除成功":"删除失败"});
    }

    [EndpointSummary("批量删除角色")]
    [EndpointDescription("根据角色ID集合批量删除角色")]
    [HttpPost("BatchDelete")]
    public async Task<IActionResult> BatchDeleteRoles([FromBody] IEnumerable<Guid> ids)
    {
        var result = await _roleService.BatchDeleteRolesAsync(ids);
        return Ok(new { deletedCount = result });
    }
}
