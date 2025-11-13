using AutoMapper;
using Core.Entity.Entities;
using Core.Persistent.Extensions.DynamicFilterModel;
using Core.Persistent.Repository;
using Core.Service.Base;
using Core.Service.Exception;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;
using Z.EntityFramework.Plus;

namespace Sys.Service.Service;

/// <summary>
/// 菜单权限服务（支持树形结构）
/// </summary>
public class MenuPermissionService : BaseMgr, IMenuPermissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger = Log.ForContext<MenuPermissionService>();
    private readonly IMapper _mapper;
    private readonly ITreeRepository<SysMenuPermission, Guid> _repository;

    public MenuPermissionService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ITreeRepository<SysMenuPermission, Guid> repository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = repository;
    }

    // ──────────────── CRUD 基础操作 ────────────────

    /// <summary>
    /// 分页查询菜单权限
    /// </summary>
    public async Task<PagedResult<SysMenuPermissionDto>> QueryAsync(PagedQueryRequest queryRequest)
    {
        var repo = _unitOfWork.Repository<SysMenuPermission, Guid>();
        var query = repo.Query();
        return await _unitOfWork.Repository<SysMenuPermission, Guid>()
            .QueryAsync<SysMenuPermissionDto>(_mapper.ConfigurationProvider, queryRequest);
    }

    /// <summary>
    /// 获取单个菜单详情
    /// </summary>
    public async Task<SysMenuPermissionDto?> GetAsync(Guid id)
    {
        var entity = await _unitOfWork.Repository<SysMenuPermission, Guid>().GetByIdAsync(id);
        return _mapper.Map<SysMenuPermissionDto>(entity);
    }

    /// <summary>
    /// 新增菜单节点（自动处理层级）
    /// </summary>
    public async Task<bool> AddAsync(SysMenuPermissionAddOrEditParams addParams)
    {
        if (string.IsNullOrWhiteSpace(addParams.Title))
            throw new BusinessException("菜单标题不能为空");

        var entity = _mapper.Map<SysMenuPermission>(addParams);
        entity.Id = Guid.NewGuid();
        entity.CreatedTime = DateTime.UtcNow;
        if (addParams.ParentId == null)
        {
            entity.ParentId = null;
        }
        
        
        // 计算 Path / Level
        if (addParams.ParentId.HasValue && addParams.ParentId != Guid.Empty)
        {
            var parent = await _unitOfWork.Repository<SysMenuPermission, Guid>()
                .GetByIdAsync(addParams.ParentId.Value);

            if (parent == null)
                throw new BusinessException("父节点不存在");

            entity.Level = parent.Level + 1;
            entity.Path = string.IsNullOrEmpty(parent.Path)
                ? parent.Id.ToString()
                : $"{parent.Path}/{parent.Id}";
        }
        else
        {
            entity.ParentId = null;
            entity.Level = 1;
            entity.Path = string.Empty;
        }

        await _unitOfWork.Repository<SysMenuPermission, Guid>().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        _logger.Information("新增菜单节点 {Title} (Id={Id})", entity.Title, entity.Id);
        return true;
    }

    /// <summary>
    /// 更新菜单节点（自动维护层级与路径）
    /// </summary>
    public async Task<bool> UpdateAsync(SysMenuPermissionAddOrEditParams updateParams)
    {
        if (string.IsNullOrWhiteSpace(updateParams.Id))
            throw new BusinessException("菜单ID不能为空");

        var repo = _unitOfWork.Repository<SysMenuPermission, Guid>();
        var id = Guid.Parse(updateParams.Id);
        var entity = await repo.GetByIdAsync(id);

        if (entity == null)
            throw new BusinessException("菜单不存在");

        _mapper.Map(updateParams, entity);
        entity.ModifyTime = DateTime.UtcNow;

        // 重新计算层级与路径
        if (updateParams.ParentId.HasValue && updateParams.ParentId != Guid.Empty)
        {
            var parent = await repo.GetByIdAsync(updateParams.ParentId.Value);
            if (parent == null)
                throw new BusinessException("父节点不存在");

            entity.Level = parent.Level + 1;
            entity.Path = string.IsNullOrEmpty(parent.Path)
                ? parent.Id.ToString()
                : $"{parent.Path}/{parent.Id}";
        }
        else
        {
            entity.ParentId = Guid.Empty;
            entity.Level = 1;
            entity.Path = string.Empty;
        }

        repo.Update(entity);
        await _unitOfWork.SaveChangesAsync();

        _logger.Information("更新菜单节点 {Title} (Id={Id})", entity.Title, entity.Id);
        return true;
    }

    /// <summary>
    /// 删除菜单节点（含所有后代）
    /// </summary>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var repo = _unitOfWork.Repository<SysMenuPermission, Guid>();
        var entity = await repo.GetByIdAsync(id);

        if (entity == null)
            throw new BusinessException("菜单不存在");

        // 删除自己及后代节点
        await _unitOfWork.GetDbContext().Set<SysMenuPermission>()
            .Where(x => x.Id == id || x.Path!.Contains(id.ToString()))
            .DeleteAsync();

        _logger.Information("删除菜单节点 {Title} 及其后代", entity.Title);
        return true;
    }

    /// <summary>
    /// 批量删除菜单节点
    /// </summary>
    public async Task<int> BatchDeleteAsync(IEnumerable<Guid> ids)
    {
        var list = ids.ToList();
        if (list.Count == 0)
            return 0;

        var count = await _unitOfWork.GetDbContext().Set<SysMenuPermission>()
            .Where(x => list.Contains(x.Id))
            .DeleteAsync();

        _logger.Information("批量删除菜单节点 {Count} 条", count);
        return count;
    }

    // ──────────────── 树结构操作 ────────────────

    public async Task<List<SysMenuPermissionDto>> GetRootNodesAsync(CancellationToken cancellationToken = default)
    {
        var roots = await _repository.GetRootNodesAsync(cancellationToken);
        return _mapper.Map<List<SysMenuPermissionDto>>(roots);
    }

    public async Task<List<SysMenuPermissionDto>> GetChildrenAsync(Guid parentId,
        CancellationToken cancellationToken = default)
    {
        var children = await _repository.GetChildrenAsync(parentId, cancellationToken);
        return _mapper.Map<List<SysMenuPermissionDto>>(children);
    }

    public async Task<List<TreeNode<SysMenuPermission, Guid>>> GetTreeAsync(Guid? rootId = null, int? maxDepth = null,
        CancellationToken cancellationToken = default)
    {
        var tree = await _repository.GetTreeAsync(rootId ?? Guid.Empty, maxDepth, cancellationToken);
        return tree;
    }

    public async Task<List<SysMenuPermissionDto>> GetTreeFlatAsync(Guid? rootId = null, int? maxDepth = null,
        CancellationToken cancellationToken = default)
    {
        var flat = await _repository.GetTreeFlatAsync(rootId ?? Guid.Empty, maxDepth, cancellationToken);
        return _mapper.Map<List<SysMenuPermissionDto>>(flat);
    }

    public async Task<List<SysMenuPermissionDto>> GetAncestorsAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var ancestors = await _repository.GetAncestorsAsync(id, cancellationToken);
        return _mapper.Map<List<SysMenuPermissionDto>>(ancestors);
    }

    public async Task<List<SysMenuPermissionDto>> GetDescendantsAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var descendants = await _repository.GetDescendantsAsync(id, cancellationToken);
        return _mapper.Map<List<SysMenuPermissionDto>>(descendants);
    }

    public async Task MoveNodeAsync(Guid id, Guid? newParentId, CancellationToken cancellationToken = default)
    {
        await _repository.MoveNodeAsync(id, newParentId ?? Guid.Empty, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.Information("菜单节点 {Id} 已移动到父节点 {ParentId}", id, newParentId);
    }

    public async Task<bool> HasChildrenAsync(Guid parentId, CancellationToken cancellationToken = default)
    {
        return await _repository.HasChildrenAsync(parentId, cancellationToken);
    }
    
    // 在 MenuPermissionService 类中添加以下实现

/// <summary>
/// 为菜单分配API
/// </summary>
public async Task<bool> AssignApisToMenuAsync(MenuApiAssignParams assignParams)
{
    if (assignParams.ApiRelations == null || !assignParams.ApiRelations.Any())
        throw new BusinessException("API列表不能为空");

    // 验证菜单是否存在
    var menuExists = await _unitOfWork.Repository<SysMenuPermission, Guid>()
        .Query()
        .AnyAsync(m => m.Id == assignParams.MenuId);

    if (!menuExists)
        throw new BusinessException("菜单不存在");

    var apiIds = assignParams.ApiRelations.Select(a => a.ApiId).ToList();

    // 验证所有API是否存在
    var validApiIds = await _unitOfWork.Repository<SysApi, Guid>()
        .Query()
        .Where(a => apiIds.Contains(a.Id))
        .Select(a => a.Id)
        .ToListAsync();

    if (validApiIds.Count != apiIds.Count)
        throw new BusinessException("部分API不存在");

    var dbContext = _unitOfWork.GetDbContext();

    // 获取已存在的关联
    var existingRelations = await dbContext.Set<SysMenuApi>()
        .Where(ma => ma.MenuId == assignParams.MenuId)
        .ToListAsync();

    var existingApiIds = existingRelations
        .Select(ma => ma.ApiId)
        .ToHashSet();

    // 找出需要新增的关联
    var newRelations = assignParams.ApiRelations
        .Where(ar => !existingApiIds.Contains(ar.ApiId))
        .Select(ar => new SysMenuApi
        {
            Id = Guid.NewGuid(),
            MenuId = assignParams.MenuId,
            ApiId = ar.ApiId,
            Required = ar.Required,
            Sort = ar.Sort,
            Remark = ar.Remark,
            CreatedTime = DateTime.UtcNow
        })
        .ToList();

    // 更新已存在的关联
    foreach (var existing in existingRelations)
    {
        var relation = assignParams.ApiRelations
            .FirstOrDefault(ar => ar.ApiId == existing.ApiId);
        
        if (relation != null)
        {
            existing.Required = relation.Required;
            existing.Sort = relation.Sort;
            existing.Remark = relation.Remark;
        }
    }

    if (newRelations.Any())
    {
        await dbContext.Set<SysMenuApi>().AddRangeAsync(newRelations);
    }

    await _unitOfWork.SaveChangesAsync();

    _logger.Information("为菜单 {MenuId} 分配了 {Count} 个API", assignParams.MenuId, newRelations.Count);
    return true;
}

/// <summary>
/// 移除菜单的API关联
/// </summary>
public async Task<bool> RemoveApisFromMenuAsync(Guid menuId, IEnumerable<Guid> apiIds)
{
    var apiIdList = apiIds.Select(id => id).ToList();
    if (!apiIdList.Any())
        throw new BusinessException("API列表不能为空");

    var removedCount = await _unitOfWork.GetDbContext().Set<SysMenuApi>()
        .Where(ma => ma.MenuId == menuId && apiIdList.Contains(ma.ApiId))
        .ExecuteDeleteAsync();

    _logger.Information("从菜单 {MenuId} 移除了 {Count} 个API关联", menuId, removedCount);
    return removedCount > 0;
}

/// <summary>
/// 获取菜单关联的所有API
/// </summary>
public async Task<List<SysMenuApiDto>> GetMenuApisAsync(Guid menuId)
{
    var menuApis = await _unitOfWork.GetDbContext().Set<SysMenuApi>()
        .Where(ma => ma.MenuId == menuId)
        .Include(ma => ma.Api)
        .OrderBy(ma => ma.Sort)
        .ToListAsync();

    return _mapper.Map<List<SysMenuApiDto>>(menuApis);
}

/// <summary>
/// 获取菜单详情（包含关联的API）
/// </summary>
public async Task<MenuWithApisDto?> GetMenuWithApisAsync(Guid menuId)
{
    var menu = await _unitOfWork.Repository<SysMenuPermission, Guid>()
        .GetByIdAsync(menuId);

    if (menu == null)
        return null;

    var menuDto = _mapper.Map<MenuWithApisDto>(menu);

    var menuApis = await GetMenuApisAsync(menuId);
    menuDto.RelatedApis = menuApis;

    return menuDto;
}

/// <summary>
/// 批量获取多个菜单关联的API
/// </summary>
public async Task<Dictionary<Guid, List<SysMenuApiDto>>> GetMenusApisAsync(IEnumerable<Guid> menuIds)
{
    var menuIdList = menuIds.Select(id => id).ToList();
    if (!menuIdList.Any())
        return new Dictionary<Guid, List<SysMenuApiDto>>();

    var menuApis = await _unitOfWork.GetDbContext().Set<SysMenuApi>()
        .Where(ma => menuIdList.Contains(ma.MenuId))
        .Include(ma => ma.Api)
        .OrderBy(ma => ma.MenuId)
        .ThenBy(ma => ma.Sort)
        .ToListAsync();

    var result = menuApis
        .GroupBy(ma => ma.MenuId)
        .ToDictionary(
            g => g.Key,
            g => _mapper.Map<List<SysMenuApiDto>>(g.ToList())
        );

    return result;
}
}