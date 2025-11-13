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
}