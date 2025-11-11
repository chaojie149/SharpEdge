using AutoMapper;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;

namespace Sys.Entity;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
       

        // 从 SysUser → SysUserDto
        CreateMap<SysUser, SysUserDto>()
            // Roles 来源：User.SysUserRoles.Select(x => x.Role)
            .ForMember(dest => dest.Roles,
                opt => opt.MapFrom(src => src.SysUserRoles.Select(ur => ur.Role)));

        // SysRole → SysRoleDto
        CreateMap<SysRole, SysRoleDto>();
        CreateMap<SysUserAddOrEditParams, SysUser>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 
                string.IsNullOrWhiteSpace(src.Id) ? Guid.Empty : Guid.Parse(src.Id)));

    }
}
