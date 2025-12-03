using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Persistent.Extensions;
using Core.Persistent.Extensions.DynamicFilterModel;
using Core.Persistent.Repository;
using Core.Service.Base;
using Core.Service.Exception;
using Core.Service.GlobalConfig;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;
using Z.EntityFramework.Plus;

namespace Sys.Service.Service;

public class RoleService(IUnitOfWork unitOfWork, IMapper mapper) : BaseMgr, IRoleService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger _logger = Log.ForContext<RoleService>();
    private readonly IMapper _mapper = mapper;

    public async Task<PagedResult<SysRoleDto>> QueryAsync(PagedQueryRequest queryRequest)
    {
        var repo = _unitOfWork.Repository<SysRole, Guid>();

        var roles = await _unitOfWork.Repository<SysRole, Guid>()
            .QueryAsync<SysRoleDto>(_mapper.ConfigurationProvider, queryRequest);
        return roles;
    }

    public async Task<SysRoleDto> GetRoleAsync(Guid roleId)
    {
        var role = await _unitOfWork.Repository<SysRole, Guid>().GetByIdAsync(roleId);
        return _mapper.Map<SysRoleDto>(role);
    }

    public async Task<List<SysRoleDto>> GetAllRoleAsync()
    {

        var roles = await _unitOfWork.Repository<SysRole, Guid>()
            .GetAllAsync();
       return _mapper.Map<List<SysRoleDto>>(roles);
    }

    public async Task<bool> AddRoleAsync(SysRoleAddOrEditParams roleParams)
    {
        if (roleParams == null)
            throw new BusinessException("参数不存在");

        if (string.IsNullOrWhiteSpace(roleParams.Name))
            throw new BusinessException("角色名称不能为空");

        if (string.IsNullOrWhiteSpace(roleParams.Code))
            throw new BusinessException("角色代码不能为空");

        var repo = _unitOfWork.Repository<SysRole, Guid>();
        bool exists = await repo.ExistsAsync(x => x.Code == roleParams.Code);
        if (exists)
            throw new BusinessException("角色代码已存在");

        var entity = _mapper.Map<SysRole>(roleParams);
        await repo.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        _logger.Information("角色 {RoleName} 添加成功", roleParams.Name);
        return true;
    }

    public async Task<bool> UpdateRoleAsync(SysRoleAddOrEditParams roleParams)
    {
        var repo = _unitOfWork.Repository<SysRole, Guid>();
        var role = await repo.GetByIdAsync(Guid.Parse(roleParams.Id));

        if (role == null)
            throw new BusinessException("角色不存在");

        _mapper.Map(roleParams, role);
        repo.Update(role);
        await _unitOfWork.SaveChangesAsync();

        _logger.Information("角色 {RoleName} 更新成功", roleParams.Name);
        return true;
    }

    public async Task<bool> DeleteRoleAsync(Guid roleId)
    {
        var repo = _unitOfWork.Repository<SysRole, Guid>();

        var role = await repo.GetByIdAsync(roleId);

        if (role != null && role.Code.Equals(AppGlobalSettings.FinalRole))
        {
            throw new BusinessException("超级管理员不允许删除");
        }

        if (role == null)
            return false;

        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var db = _unitOfWork.GetDbContext();

            // 1. 删除关联表中的所有记录
            var userRoles = db.Set<SysUserRole>().Where(ur => ur.RoleId == roleId);
            
            db.Set<SysUserRole>().RemoveRange(userRoles);

            repo.Delete(role);
            
            await _unitOfWork.SaveChangesAsync();
        });
        
     
        _logger.Information("角色 {RoleId} 已删除", roleId);
        return true;
    }

    public async Task<int> BatchDeleteRolesAsync(IEnumerable<Guid> roleIds)
    {
        return await _unitOfWork
            .GetDbContext()
            .Set<SysRole>()
            .Where(r => roleIds.Contains(r.Id))
            .DeleteAsync();
    }
}