using AutoMapper;
using Core.Entity.Entities;
using Core.Persistent.Repository;
using Core.Service.Base;
using Core.Service.Exception;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;

namespace Sys.Service.Service;

/// <summary>
/// 权限分配服务实现
/// </summary>
public class PermissionService : BaseMgr, IPermissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger = Log.ForContext<PermissionService>();
    private readonly IMapper _mapper;
    private readonly ITreeRepository<SysMenuPermission, Guid> _menuRepository;

    public PermissionService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ITreeRepository<SysMenuPermission, Guid> menuRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _menuRepository = menuRepository;
    }

    // ──────────────── 用户角色分配 ────────────────

    public async Task<bool> AssignRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds)
    {
        var roleIdList = roleIds.ToList();
        if (roleIdList.Count == 0)
            throw new BusinessException("角色列表不能为空");

        // 验证用户是否存在
        var userExists = await _unitOfWork.Repository<SysUser, Guid>()
            .Query()
            .AnyAsync(u => u.Id == userId);
        
        if (!userExists)
            throw new BusinessException("用户不存在");

        // 验证所有角色是否存在且启用
        var validRoles = await _unitOfWork.Repository<SysRole, Guid>()
            .Query()
            .Where(r => roleIdList.Contains(r.Id) && r.Enable == true)
            .Select(r => r.Id)
            .ToListAsync();

        if (validRoles.Count != roleIdList.Count)
            throw new BusinessException("部分角色不存在或未启用");

        // 获取已存在的用户角色关系
        var existingRoles = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId!.Value)  // ✅ 转 Guid
            .ToListAsync();

        // 找出需要新增的角色
        var newRoles = roleIdList.Except(existingRoles).ToList();

        if (newRoles.Count > 0)
        {
            var userRoles = newRoles.Select(roleId => new SysUserRole
            {
                UserId = userId,
                RoleId = roleId
            }).ToList();

            await _unitOfWork.GetDbContext().Set<SysUserRole>().AddRangeAsync(userRoles);
            await _unitOfWork.SaveChangesAsync();

            _logger.Information("为用户 {UserId} 分配了 {Count} 个角色", userId, newRoles.Count);
        }

        return true;
    }

    public async Task<bool> RemoveRolesFromUserAsync(Guid userId, IEnumerable<Guid> roleIds)
    {
        var roleIdList = roleIds.ToList();
        if (roleIdList.Count == 0)
            throw new BusinessException("角色列表不能为空");

        var removedCount = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId && ur.RoleId.HasValue && roleIdList.Contains(ur.RoleId.Value))
            .ExecuteDeleteAsync();

        _logger.Information("从用户 {UserId} 移除了 {Count} 个角色", userId, removedCount);
        return removedCount > 0;
    }

    public async Task<List<SysRoleDto>> GetUserRolesAsync(Guid userId)
    {
        var roles = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.Role)
            .Select(ur => ur.Role)
            .ToListAsync();

        return _mapper.Map<List<SysRoleDto>>(roles);
    }

    public async Task<List<SysUserDto>> GetRoleUsersAsync(Guid roleId)
    {
        var users = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.RoleId == roleId)
            .Include(ur => ur.User)
            .Select(ur => ur.User)
            .ToListAsync();

        return _mapper.Map<List<SysUserDto>>(users);
    }

    // ──────────────── 角色权限分配 ────────────────

    public async Task<bool> AssignPermissionsToRoleAsync(RolePermissionAssignParams assignParams)
    {
        if (assignParams.MenuPermissionIds == null && assignParams.ApiPermissionIds == null)
            throw new BusinessException("至少需要分配一种权限");

        // 验证角色是否存在
        var roleExists = await _unitOfWork.Repository<SysRole, Guid>()
            .Query()
            .AnyAsync(r => r.Id == assignParams.RoleId);

        if (!roleExists)
            throw new BusinessException("角色不存在");

        var dbContext = _unitOfWork.GetDbContext();
        var newPermissions = new List<SysRolePermission>();

        // 处理菜单权限
        if (assignParams.MenuPermissionIds?.Any() == true)
        {
            // 验证菜单权限是否存在
            var validMenuIds = await _unitOfWork.Repository<SysMenuPermission, Guid>()
                .Query()
                .Where(m => assignParams.MenuPermissionIds.Contains(m.Id))
                .Select(m => m.Id)
                .ToListAsync();

            if (validMenuIds.Count != assignParams.MenuPermissionIds.Count())
                throw new BusinessException("部分菜单权限不存在");

            // 获取已存在的菜单权限
            var existingMenuPermissions = await dbContext.Set<SysRolePermission>()
                .Where(rp => rp.RoleId == assignParams.RoleId && rp.PermissionType == "menu")
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            // 找出需要新增的菜单权限
            var newMenuPermissions = validMenuIds
                .Except(existingMenuPermissions.Select(Guid.Parse))
                .Select(menuId => new SysRolePermission
                {
                    Id = Guid.NewGuid(),
                    RoleId = assignParams.RoleId,
                    PermissionId = menuId.ToString(),
                    PermissionType = "menu",
                    CreatedTime = DateTime.UtcNow
                });

            newPermissions.AddRange(newMenuPermissions);
        }

        // 处理API权限
        if (assignParams.ApiPermissionIds?.Any() == true)
        {
            // 验证API权限是否存在
            var validApiIds = await _unitOfWork.Repository<SysApi, Guid>()
                .Query()
                .Where(a => assignParams.ApiPermissionIds.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();

            if (validApiIds.Count != assignParams.ApiPermissionIds.Count())
                throw new BusinessException("部分API权限不存在");

            // 获取已存在的API权限
            var existingApiPermissions = await dbContext.Set<SysRolePermission>()
                .Where(rp => rp.RoleId == assignParams.RoleId && rp.PermissionType == "api")
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            // 找出需要新增的API权限
            var newApiPermissions = validApiIds
                .Except(existingApiPermissions.Select(Guid.Parse))
                .Select(apiId => new SysRolePermission
                {
                    Id = Guid.NewGuid(),
                    RoleId = assignParams.RoleId,
                    PermissionId = apiId.ToString(),
                    PermissionType = "api",
                    CreatedTime = DateTime.UtcNow
                });

            newPermissions.AddRange(newApiPermissions);
        }

        if (newPermissions.Count > 0)
        {
            await dbContext.Set<SysRolePermission>().AddRangeAsync(newPermissions);
            await _unitOfWork.SaveChangesAsync();

            _logger.Information("为角色 {RoleId} 分配了 {Count} 个权限", assignParams.RoleId, newPermissions.Count);
        }

        return true;
    }

    public async Task<bool> RemovePermissionsFromRoleAsync(Guid roleId, IEnumerable<Guid> permissionIds, string permissionType)
    {
        var permissionIdList = permissionIds.Select(id => id.ToString()).ToList();
        if (permissionIdList.Count == 0)
            throw new BusinessException("权限列表不能为空");

        if (permissionType != "menu" && permissionType != "api")
            throw new BusinessException("权限类型必须是 'menu' 或 'api'");

        var removedCount = await _unitOfWork.GetDbContext().Set<SysRolePermission>()
            .Where(rp => rp.RoleId == roleId 
                && permissionIdList.Contains(rp.PermissionId!) 
                && rp.PermissionType == permissionType)
            .ExecuteDeleteAsync();

        _logger.Information("从角色 {RoleId} 移除了 {Count} 个 {Type} 权限", roleId, removedCount, permissionType);
        return removedCount > 0;
    }

    public async Task<RolePermissionsDto> GetRolePermissionsAsync(Guid roleId)
    {
        var rolePermissions = await _unitOfWork.GetDbContext().Set<SysRolePermission>()
            .Where(rp => rp.RoleId == roleId)
            .ToListAsync();

        var menuPermissionIds = rolePermissions
            .Where(rp => rp.PermissionType == "menu")
            .Select(rp => Guid.Parse(rp.PermissionId!))
            .ToList();

        var apiPermissionIds = rolePermissions
            .Where(rp => rp.PermissionType == "api")
            .Select(rp => Guid.Parse(rp.PermissionId!))
            .ToList();

        // 获取菜单权限详情
        var menuPermissions = menuPermissionIds.Count > 0
            ? await _unitOfWork.Repository<SysMenuPermission, Guid>()
                .Query()
                .Where(m => menuPermissionIds.Contains(m.Id))
                .ToListAsync()
            : new List<SysMenuPermission>();

        // 获取API权限详情
        var apiPermissions = apiPermissionIds.Count > 0
            ? await _unitOfWork.Repository<SysApi, Guid>()
                .Query()
                .Where(a => apiPermissionIds.Contains(a.Id))
                .ToListAsync()
            : new List<SysApi>();

        return new RolePermissionsDto
        {
            RoleId = roleId,
            MenuPermissions = _mapper.Map<List<SysMenuPermissionDto>>(menuPermissions),
            ApiPermissions = _mapper.Map<List<SysApiDto>>(apiPermissions)
        };
    }

    public async Task<List<SysRoleDto>> GetPermissionRolesAsync(Guid permissionId, string permissionType)
    {
        if (permissionType != "menu" && permissionType != "api")
            throw new BusinessException("权限类型必须是 'menu' 或 'api'");

        var roles = await _unitOfWork.GetDbContext().Set<SysRolePermission>()
            .Where(rp => rp.PermissionId == permissionId.ToString() && rp.PermissionType == permissionType)
            .Include(rp => rp.Role)
            .Select(rp => rp.Role)
            .ToListAsync();

        return _mapper.Map<List<SysRoleDto>>(roles);
    }

    // ──────────────── 用户权限查询（合并） ────────────────

    public async Task<UserPermissionsDto> GetUserPermissionsAsync(Guid userId)
    {
        // 获取用户的所有角色
        var userRoleIds = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .ToListAsync();

        if (userRoleIds.Count == 0)
        {
            return new UserPermissionsDto
            {
                UserId = userId,
                Roles = new List<SysRoleDto>(),
                MenuPermissions = new List<SysMenuPermissionDto>(),
                ApiPermissions = new List<SysApiDto>()
            };
        }

        // 获取角色详情
        var roles = await _unitOfWork.Repository<SysRole, Guid>()
            .Query()
            .Where(r => userRoleIds.Contains(r.Id) && r.Enable == true)
            .ToListAsync();

        var enabledRoleIds = roles.Select(r => r.Id).ToList();

        // 获取所有角色的权限（合并）
        var rolePermissions = await _unitOfWork.GetDbContext().Set<SysRolePermission>()
            .Where(rp => enabledRoleIds.Contains(rp.RoleId!.Value))
            .ToListAsync();

        // 提取并去重菜单权限ID
        var menuPermissionIds = rolePermissions
            .Where(rp => rp.PermissionType == "menu")
            .Select(rp => Guid.Parse(rp.PermissionId!))
            .Distinct()
            .ToList();

        // 提取并去重API权限ID
        var apiPermissionIds = rolePermissions
            .Where(rp => rp.PermissionType == "api")
            .Select(rp => Guid.Parse(rp.PermissionId!))
            .Distinct()
            .ToList();

        // 查询菜单权限详情
        var menuPermissions = menuPermissionIds.Count > 0
            ? await _unitOfWork.Repository<SysMenuPermission, Guid>()
                .Query()
                .Where(m => menuPermissionIds.Contains(m.Id))
                .OrderBy(m => m.Level)
                .ThenBy(m => m.ParentId)
                .ToListAsync()
            : new List<SysMenuPermission>();

        // 查询API权限详情
        var apiPermissions = apiPermissionIds.Count > 0
            ? await _unitOfWork.Repository<SysApi, Guid>()
                .Query()
                .Where(a => apiPermissionIds.Contains(a.Id))
                .ToListAsync()
            : new List<SysApi>();

        return new UserPermissionsDto
        {
            UserId = userId,
            Roles = _mapper.Map<List<SysRoleDto>>(roles),
            MenuPermissions = _mapper.Map<List<SysMenuPermissionDto>>(menuPermissions),
            ApiPermissions = _mapper.Map<List<SysApiDto>>(apiPermissions)
        };
    }

    public async Task<List<TreeNode<SysMenuPermission, Guid>>> GetUserMenuTreeAsync(Guid userId, int? maxDepth = null, CancellationToken cancellationToken = default)
    {
        // 获取用户的所有菜单权限ID（合并去重）
        var menuPermissionIds = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Join(
                _unitOfWork.GetDbContext().Set<SysRole>().Where(r => r.Enable == true),
                ur => ur.RoleId,
                r => r.Id,
                (ur, r) => r.Id
            )
            .Join(
                _unitOfWork.GetDbContext().Set<SysRolePermission>().Where(rp => rp.PermissionType == "menu"),
                roleId => roleId,
                rp => rp.RoleId,
                (roleId, rp) => Guid.Parse(rp.PermissionId!)
            )
            .Distinct()
            .ToListAsync(cancellationToken);

        if (menuPermissionIds.Count == 0)
            return new List<TreeNode<SysMenuPermission, Guid>>();

        // 获取所有相关的菜单节点（包括父节点，确保树完整）
        var allMenus = await _unitOfWork.Repository<SysMenuPermission, Guid>()
            .Query()
            .Where(m => menuPermissionIds.Contains(m.Id))
            .ToListAsync(cancellationToken);

        // 获取所有需要的祖先节点
        var ancestorIds = new HashSet<Guid>();
        foreach (var menu in allMenus)
        {
            if (!string.IsNullOrEmpty(menu.Path))
            {
                var pathIds = menu.Path.Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse);
                foreach (var id in pathIds)
                    ancestorIds.Add(id);
            }
        }

        // 如果有祖先节点不在已有列表中，补充查询
        var missingAncestorIds = ancestorIds.Except(allMenus.Select(m => m.Id)).ToList();
        if (missingAncestorIds.Count > 0)
        {
            var ancestors = await _unitOfWork.Repository<SysMenuPermission, Guid>()
                .Query()
                .Where(m => missingAncestorIds.Contains(m.Id))
                .ToListAsync(cancellationToken);
            
            allMenus.AddRange(ancestors);
        }

        // 构建树形结构
        return BuildMenuTree(allMenus, null, maxDepth, 0);
    }

    private List<TreeNode<SysMenuPermission, Guid>> BuildMenuTree(
        List<SysMenuPermission> allMenus, 
        Guid? parentId, 
        int? maxDepth, 
        int currentDepth)
    {
        if (maxDepth.HasValue && currentDepth >= maxDepth.Value)
            return new List<TreeNode<SysMenuPermission, Guid>>();

        var children = allMenus
            .Where(m => m.ParentId == parentId)
            .OrderBy(m => m.Level)
            .Select(m => new TreeNode<SysMenuPermission, Guid>
            {
                Data = m,
                Children = BuildMenuTree(allMenus, m.Id, maxDepth, currentDepth + 1)
            })
            .ToList();

        return children;
    }

    public async Task<List<SysApiDto>> GetUserApisAsync(Guid userId)
    {
        var apis = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Join(
                _unitOfWork.GetDbContext().Set<SysRole>().Where(r => r.Enable == true),
                ur => ur.RoleId,
                r => r.Id,
                (ur, r) => r.Id
            )
            .Join(
                _unitOfWork.GetDbContext().Set<SysRolePermission>().Where(rp => rp.PermissionType == "api"),
                roleId => roleId,
                rp => rp.RoleId,
                (roleId, rp) => Guid.Parse(rp.PermissionId!)
            )
            .Distinct()
            .Join(
                _unitOfWork.Repository<SysApi, Guid>().Query(),
                permissionId => permissionId,
                api => api.Id,
                (permissionId, api) => api
            )
            .ToListAsync();

        return _mapper.Map<List<SysApiDto>>(apis);
    }

    public async Task<bool> CheckUserPermissionAsync(Guid userId, string permissionCode)
    {
        if (string.IsNullOrWhiteSpace(permissionCode))
            return false;

// 1️⃣ 获取用户拥有的所有角色权限
        var rolePermissions = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Join(
                _unitOfWork.GetDbContext().Set<SysRole>().Where(r => r.Enable == true),
                ur => ur.RoleId,
                r => r.Id,
                (ur, r) => r.Id
            )
            .Join(
                _unitOfWork.GetDbContext().Set<SysRolePermission>(),
                roleId => roleId,
                rp => rp.RoleId,
                (roleId, rp) => rp
            )
            .ToListAsync();

// 2️⃣ 在内存中过滤
        bool hasPermission = false;

        foreach (var rp in rolePermissions)
        {
            if (rp.PermissionType == "menu")
            {
                hasPermission = await _unitOfWork.Repository<SysMenuPermission, Guid>()
                    .Query()
                    .AnyAsync(m => m.Id == Guid.Parse(rp.PermissionId!) && m.PermissionCode == permissionCode);
            }
            else if (rp.PermissionType == "api")
            {
                hasPermission = await _unitOfWork.Repository<SysApi, Guid>()
                    .Query()
                    .AnyAsync(a => a.Id == Guid.Parse(rp.PermissionId!) && a.PermissionCode == permissionCode);
            }

            if (hasPermission)
                break;
        }

        return hasPermission;
    }

    public async Task<bool> CheckUserRoleAsync(Guid userId, string roleCode)
    {
        if (string.IsNullOrWhiteSpace(roleCode))
            return false;

        var hasRole = await _unitOfWork.GetDbContext().Set<SysUserRole>()
            .Where(ur => ur.UserId == userId)
            .Join(
                _unitOfWork.Repository<SysRole, Guid>().Query(),
                ur => ur.RoleId,
                r => r.Id,
                (ur, r) => r
            )
            .AnyAsync(r => r.Code == roleCode && r.Enable == true);

        return hasRole;
    }
}