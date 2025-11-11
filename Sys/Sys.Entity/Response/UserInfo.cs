using Sys.Entity.Dtos;

namespace Sys.Entity.Response
{

    //登录返回用户信息
    public  class UserInfo
    {
      

        public required string Username { get; set; }
        
        public required string RealName { get; set; }


        public string? Email { get; set; }


        public DateTime? LastLoginTime{ get; set; }
        
        //角色信息
        public IEnumerable<SysRoleDto>? Roles { get; set; }


    }
}
