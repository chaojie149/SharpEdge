using AutoMapper;
using Core.Entity.Entities;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Entity.Params;

namespace Sys.Service;

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
        CreateMap<SysRoleAddOrEditParams, SysRole>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src =>
                string.IsNullOrEmpty(src.Id) ? Guid.NewGuid() : Guid.Parse(src.Id)));
        
        
        CreateMap<SysMenuPermissionAddOrEditParams, SysMenuPermission>()
            .ForMember(d => d.Id, opt => opt.Ignore()); // 避免覆盖主键
        CreateMap<SysMenuPermission, SysMenuPermissionDto>();
        
        
        // 实体到DTO
        CreateMap<SysMenuPermission, SysMenuPermissionDto>().ReverseMap();

        // ✅ 修复关键：TreeNode<SysMenuPermission, Guid> -> SysMenuPermissionDto
        // CreateMap<TreeNode<SysMenuPermission, Guid>, SysMenuPermissionDto>()
        //     .ForMember(dest => dest, opt => opt.MapFrom(src => src.Data)) // 映射 Data 属性里的实体
        //     .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children)) // 映射 Children
        //     .ReverseMap();
    }
}
