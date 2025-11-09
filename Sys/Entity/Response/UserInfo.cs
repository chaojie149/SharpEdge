using System;
using System.Collections.Generic;
using System.Text;
using Sys.Entity.Dtos;
using Sys.Entity.Models;

namespace Sys.Entity.Response
{

    //登录返回用户信息
    public  class UserInfo
    {
        public required string Token { get; set; }

        public required string Username { get; set; }
        
        public required string RealName { get; set; }


        public string? Email { get; set; }


        public DateTime? LastLoginTime{ get; set; }
        
        //角色信息
        public IEnumerable<SysRoleDto>? Roles { get; set; }

        //菜单权限信息
        public IEnumerable<SysMenuPermission>? MenuPermissions;
    }
}
