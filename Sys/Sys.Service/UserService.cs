using Core.Persistent.Repository;
using Microsoft.Extensions.Logging;
using Sys.Entity.Models;

namespace Sys.Service;

public class UserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;

    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    // 基础CRUD示例
    public async Task<SysUser?> GetUserByIdAsync(Guid id)
    {
        return await _unitOfWork
            .Repository<SysUser, Guid>()
            .GetByIdAsync(id);
    }

    public async Task<List<SysUser>> GetActiveSysUsersAsync()
    {
        return await _unitOfWork
            .Repository<SysUser, Guid>()
            .GetAllAsync();
    }


    public async Task<List<SysUser>> GetRootSysUsersAsync()
    {
        return await _unitOfWork.Repository<SysUser, Guid>().GetAllAsync();
    }
    
    public async Task<List<SysRole>> GetRoleAsync()
    {
        Console.WriteLine($"Current DbContext: {_unitOfWork.GetDbContext().GetType().FullName}");

        return await _unitOfWork.Repository<SysRole, Guid>().GetAllAsync();
    }

    public async Task<SysRole> AddRoleAsync(SysRole role)
    {
        await _unitOfWork.Repository<SysRole, Guid>().AddAsync(role);
        await _unitOfWork.SaveChangesAsync();
        return role;
    }
    public async Task<SysApi> AddApiPermission(SysApi sysApi)
    {
        await _unitOfWork.Repository<SysApi, Guid>().AddAsync(sysApi);
        await _unitOfWork.SaveChangesAsync();
        return sysApi;
    }

}
