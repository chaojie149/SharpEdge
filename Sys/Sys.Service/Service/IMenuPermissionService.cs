using Core.Entity.Entities;
using Core.Persistent.Extensions.DynamicFilterModel;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;

namespace Sys.Service.Service;

/// <summary>
/// 菜单权限服务接口（支持树形结构操作）
/// </summary>
public interface IMenuPermissionService
{

    /// <summary>
    /// 分页查询菜单权限
    /// </summary>
    public Task<PagedResult<SysMenuPermissionDto>> QueryAsync(PagedQueryRequest queryRequest);

    /// <summary>
    /// 获取所有根节点
    /// </summary>
    Task<List<SysMenuPermissionDto>> GetRootNodesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取指定节点的所有子节点（仅一级）
    /// </summary>
    Task<List<SysMenuPermissionDto>> GetChildrenAsync(Guid parentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取完整树形结构（嵌套结构）
    /// </summary>
    Task<List<TreeNode<SysMenuPermission, Guid>>> GetTreeAsync(Guid? rootId = null, int? maxDepth = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取树形结构（扁平列表）
    /// </summary>
    Task<List<SysMenuPermissionDto>> GetTreeFlatAsync(Guid? rootId = null, int? maxDepth = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取指定节点的所有祖先节点
    /// </summary>
    Task<List<SysMenuPermissionDto>> GetAncestorsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取指定节点的所有后代节点（递归）
    /// </summary>
    Task<List<SysMenuPermissionDto>> GetDescendantsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 移动节点到新的父节点下
    /// </summary>
    Task MoveNodeAsync(Guid id, Guid? newParentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 判断指定节点是否有子节点
    /// </summary>
    Task<bool> HasChildrenAsync(Guid parentId, CancellationToken cancellationToken = default);
    
    
    /// <summary>
    /// 获取菜单详情
    /// </summary>
    Task<SysMenuPermissionDto?> GetAsync(Guid id);

    /// <summary>
    /// 添加新菜单节点
    /// </summary>
    Task<bool> AddAsync(SysMenuPermissionAddOrEditParams addParams);

    /// <summary>
    /// 更新菜单节点
    /// </summary>
    Task<bool> UpdateAsync(SysMenuPermissionAddOrEditParams updateParams);

    /// <summary>
    /// 删除菜单节点
    /// </summary>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// 批量删除菜单节点
    /// </summary>
    Task<int> BatchDeleteAsync(IEnumerable<Guid> ids);

}