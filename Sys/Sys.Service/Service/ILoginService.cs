using Sys.Entity.Params;
using Sys.Entity.Response;

namespace Sys.Service.Service
{
    public interface ILoginService
    {

        //登录接口
        public Task<UserInfo> Login(LoginRequestParams loginRequestParams);

    
        
        public Task<UserInfo> RefreshToken(string refreshToken);


        public Task Logout();
    }
}
