using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Entity.Params;
using Sys.Service;
using Sys.Service.Service;

namespace Sys.WebApi.Controllers;

[Tags("Authorization")]
[ApiController]
[Route("[controller]")]

public class AuthController(ILoginService loginService) : ControllerBase
{
    [EndpointDescription("请求登录，返回token和用户信息")]
    [EndpointSummary("用户登录接口")]
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequestParams  loginRequestParams)
    {
        return Ok(await loginService.Login(loginRequestParams));
    }
    
    
    [EndpointDescription("刷新token，返回token和用户信息")]
    [EndpointSummary("刷新token")]
    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        return Ok(await loginService.RefreshToken(refreshToken));
    }

    [EndpointDescription("登出,token加入黑名单")]
    [EndpointSummary("登出")]
    [HttpPost("[action]")]
    public async Task Logout()
    {
        await loginService.Logout();
    }
}