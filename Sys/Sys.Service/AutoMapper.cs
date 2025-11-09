using AutoMapper;
using Sys.Entity.Dtos;
using Sys.Entity.Models;

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

    }
}
