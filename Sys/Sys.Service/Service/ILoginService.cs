using Sys.Entity.Params;
using Sys.Entity.Response;

namespace Sys.Service.Service
{
    public interface ILoginService
    {

        //登录接口
        public Task<LoginResponse> Login(LoginRequestParams loginRequestParams);

    
        
        public Task<LoginResponse> RefreshToken(string refreshToken);


        public Task Logout();
    }
}
