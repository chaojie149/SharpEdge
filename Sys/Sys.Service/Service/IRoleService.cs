using Core.Persistent.Extensions.DynamicFilterModel;
using Sys.Entity.Dtos;
using Sys.Entity.Params;

namespace Sys.Service.Service;

/// <summary>
/// 角色业务接口
/// </summary>
public interface IRoleService
{
    Task<PagedResult<SysRoleDto>> QueryAsync(PagedQueryRequest queryRequest);

    Task<SysRoleDto> GetRoleAsync(Guid roleId);

    Task<bool> AddRoleAsync(SysRoleAddOrEditParams roleParams);

    Task<bool> UpdateRoleAsync(SysRoleAddOrEditParams roleParams);

    Task<bool> DeleteRoleAsync(Guid roleId);

    Task<int> BatchDeleteRolesAsync(IEnumerable<Guid> roleIds);
}