using Core.Persistent.Extensions.DynamicFilterModel;
using Sys.Entity.Dtos;
using Sys.Entity.Params;

namespace Sys.Service.Service;



public interface IUserService
{
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="queryRequest"></param>
    /// <returns></returns>
     public Task<PagedResult<SysUserDto>> QueryAsync(PagedQueryRequest  queryRequest);
     
    /// <summary>
    /// 根据id查询
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
     public Task<SysUserDto> GetUserAsync(Guid userId);
     
    /// <summary>
    /// 根据用户名查询
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
     public Task<SysUserDto> GetUserByNameAsync(string userName);
     
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="userAddParams"></param>
    /// <returns></returns>
     public Task<bool> AddUserAsync(SysUserAddOrEditParams  userAddParams);
     
    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="userAddParams"></param>
    /// <returns></returns>
     public Task<bool> UpdateUserAsync(SysUserAddOrEditParams  userAddParams);
     
    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
     public Task<bool> DeleteUserAsync(Guid userId);
     
    
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="userIds"></param>
    /// <returns></returns>
     public Task<int> BatchDeleteUsersAsync(IEnumerable<Guid> userIds);
     
     
}