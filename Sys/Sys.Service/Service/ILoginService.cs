using Sys.Entity.Params;
using Sys.Entity.Response;

namespace Sys.Service
{
    public interface ILoginService
    {

        //登录接口
        public Task<UserInfo> Login(LoginRequestParams loginRequestParams);
    }
}
