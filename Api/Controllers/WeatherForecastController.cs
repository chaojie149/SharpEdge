using Example.Entity.Data.Entities;
using Example.Service;
using FastNetPro;
using Microsoft.AspNetCore.Mvc;
using Sys.Entity.Models;
using Sys.Service;

namespace Api.Controllers
{
    
    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly UserService _userService;
        private readonly ExampleService _exampleService;

        public WeatherForecastController(UserService userService, ExampleService exampleService)
        {
            _userService = userService;
            _exampleService = exampleService;
        }

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<SysRole>> Get()
        {

            IList<SysRole> sysRoles = await _userService.GetRoleAsync();
            
            return sysRoles;
        }
        
        [HttpGet("add")]
        public async Task<SysRole> AddRole()
        {

            SysRole sysRole = new SysRole();

            sysRole.Code = "TEST";
            sysRole.Name = "TEST";
            sysRole.Enable  = 1;
            await _userService.AddRoleAsync(sysRole);
            return sysRole;
        }

        [HttpGet("addApi")]
        public async Task<SysApi> AddApi()
        {

            SysApi sysApi = new SysApi();

            sysApi.Method = "POST";
            sysApi.Name = "添加接口";
            sysApi.Module  = "SYS";
            sysApi.PermissionCode  = "SYS:AddApi";
            sysApi.Path = "/api";
            
            await _userService.AddApiPermission(sysApi);
            return sysApi;
        }
        
        [HttpGet("testDb")]
        public async Task<IEnumerable<GoAdmin>> TestDbAsync()
        {

           
            ;
            return await _exampleService.GetAllUserAsync();
        }
    }
}
