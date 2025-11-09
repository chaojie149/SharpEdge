using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Entity.Params;
using Sys.Service;

namespace Sys.WebApi.Controllers;

[Tags("Authorization")]
[ApiController]
[Route("[controller]")]

public class AuthController:ControllerBase
{
    
    
    private readonly ILoginService _loginService;


    public AuthController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [EndpointDescription("请求登录，返回token和用户信息")]
    [EndpointSummary("用户登录接口")]
    [HttpPost(Name = "/login")]
    public async Task<IActionResult> Login(LoginRequestParams  loginRequestParams)
    {
        return Ok(await _loginService.Login(loginRequestParams));
    }
    

}