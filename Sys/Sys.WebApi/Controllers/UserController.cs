using Core.Persistent.Extensions.DynamicFilterModel;
using Core.Service.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sys.Entity.Dtos;
using Sys.Entity.Params;
using Sys.Service.Service;

namespace Sys.WebApi.Controllers;

/// <summary>
/// 用户管理接口
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// 分页查询用户列表
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<PagedResult<SysUserDto>>> Query([FromBody] PagedQueryRequest queryRequest)
    {
        var result = await _userService.QueryAsync(queryRequest);
        return Ok(result);
    }

    /// <summary>
    /// 根据用户ID获取用户详情
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SysUserDto>> Get(Guid id)
    {
        var user = await _userService.GetUserAsync(id);

        return Ok(user);
    }

    /// <summary>
    /// 根据用户名查询用户
    /// </summary>
    [HttpGet("{userName}")]
    public async Task<ActionResult<SysUserDto>> GetByName(string userName)
    {
        var user = await _userService.GetUserByNameAsync(userName);

        return Ok(user);
    }

    /// <summary>
    /// 新增用户
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] SysUserAddOrEditParams userParams)
    {
        try
        {
            await _userService.AddUserAsync(userParams);
            return Ok(new { message = "添加成功" });
        }
        catch (BusinessException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] SysUserAddOrEditParams userParams)
    {
        try
        {
            await _userService.UpdateUserAsync(userParams);
            return Ok(new { message = "更新成功" });
        }
        catch (BusinessException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// 删除单个用户
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _userService.DeleteUserAsync(id);
        if (!success)
            return NotFound();

        return Ok(new { message = "删除成功" });
    }

    /// <summary>
    /// 批量删除用户
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> BatchDelete([FromBody] IEnumerable<Guid> userIds)
    {
        var count = await _userService.BatchDeleteUsersAsync(userIds);
        return Ok(new { message = $"已删除 {count} 条记录" });
    }
}
