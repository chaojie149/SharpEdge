using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Persistent.Extensions;
using Core.Persistent.Extensions.DynamicFilterModel;
using Core.Persistent.Repository;
using Core.Service.Base;
using Core.Service.Cache;
using Core.Service.Exception;
using Core.Service.GlobalConfig;
using Core.Service.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Serilog;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;
using Z.EntityFramework.Plus;

namespace Sys.Service.Service;

public class UserService:BaseMgr,IUserService
{
    
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger = Log.ForContext<UserService>();
    private readonly IMapper _mapper;
    private readonly IRedisManager _redisManager;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IRedisManager redisManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _redisManager = redisManager;
    }

    public async Task<PagedResult<SysUserDto>> QueryAsync(PagedQueryRequest  queryRequest)
    {

        return await _unitOfWork.Repository<SysUser, Guid>()
            .QueryAsync<SysUserDto>(_mapper.ConfigurationProvider, queryRequest);
    }

    public async Task<SysUserDto> GetUserAsync(Guid userId)
    {
       SysUser? sysUser =  await _unitOfWork.Repository<SysUser, Guid>().GetByIdAsync(userId);
       return _mapper.Map<SysUserDto>(sysUser);
    }

    public async Task<SysUserDto> GetUserByNameAsync(string userName)
    {
        SysUser? sysUser =  await _unitOfWork.Repository<SysUser, Guid>().Query().FirstOrDefaultAsync(x=>x.Username.Equals(userName));
        return _mapper.Map<SysUserDto>(sysUser);
    }

    public async Task<bool> AddUserAsync(SysUserAddOrEditParams userAddParams)
    {
        if (userAddParams == null)
        {
            throw new BusinessException("参数不存在");
        }

        if (string.IsNullOrEmpty(userAddParams.Name))
        {
            throw new BusinessException("用户名不能为空");
        }
        if (userAddParams.Name.Length > 10)
        {
            throw new BusinessException("用户名不能大于10位");
        }
        if (string.IsNullOrEmpty(userAddParams.Password))
        {
            throw new BusinessException("密码不能为空");
        }
        
        if (userAddParams.Password.Length > 8)
        {
            throw new BusinessException("密码不能大于8位");
        }

        userAddParams.Password =
            PasswordHelper.HashPassword(userAddParams.Password, AppGlobalSettings.AuthConfig!.SecretKey);
    
        SysUser sysUser = _mapper.Map<SysUser>(userAddParams);

        await _unitOfWork.Repository<SysUser, Guid>().AddAsync(sysUser);

        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUserAsync(SysUserAddOrEditParams userAddParams)
    {
        var repo = _unitOfWork.Repository<SysUser, Guid>();
        var sysUser = await repo.GetByIdAsync(Guid.Parse(userAddParams.Id));

        if (sysUser == null)
            throw new BusinessException("用户不存在");

        _mapper.Map(userAddParams, sysUser); // 映射到现有实体
        repo.Update(sysUser);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        SysUser? sysUser = await _unitOfWork.Repository<SysUser, Guid>().GetByIdAsync(userId);

        if (sysUser == null)
        {
            return false;
        }

        _unitOfWork.Repository<SysUser, Guid>().Delete(sysUser);
        await _unitOfWork.SaveChangesAsync();

         return true;
    }

    public async Task<int> BatchDeleteUsersAsync(IEnumerable<Guid> userIds)
    {

      return  await _unitOfWork.GetDbContext().Set<SysUser>().Where(u => userIds.Contains(u.Id)).DeleteAsync();
      
    }
}