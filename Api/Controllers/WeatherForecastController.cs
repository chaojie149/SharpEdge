using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Persistent.Repository;
using Example.Entity.Data.Entities;
using Example.Service;
using FastNetPro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sys.Entity.Dtos;
using Sys.Entity.Models;
using Sys.Service;

namespace Api.Controllers
{
    
    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ILoginService _userService;


        public WeatherForecastController(IUnitOfWork unitOfWork, IMapper mapper, ILoginService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTest()
        {


             // await _unitOfWork.Repository<SysLoginLog, Guid>().AddAsync(new SysLoginLog()
             // {
             //     Ip = "127.0.0.1",
             //     Username = "Admin",
             //     Device = "Iphone",
             //     LogDate = DateTime.Now,
             //     RequestHeader = "{}",
             //     Status = 1
             // });
             await _unitOfWork.Repository<SysApi, Guid>().AddAsync(new SysApi()
             {
               Name = "ok",
               Method = ".api",
               Path = "/a",
               Module = "Sys",
               PermissionCode = "ok"
             });
             await _unitOfWork.SaveChangesAsync();
             await _unitOfWork.CommitTransactionAsync();

            return Ok();
        }

        [HttpPost("t1")]
        public async Task<IActionResult> t1()
        {

            //var sysUser = await _unitOfWork.Repository<SysUser, Guid>()
            //    .Query()
            //    //.Select(u => new
            //    //{
            //    //    u.Id,
            //    //    u.Username,
            //    //    u.Name,
            //    //    Roles = u.SysUserRoles
            //    //        .Select(ur => new
            //    //        {
            //    //            ur.Role.Id,
            //    //            ur.Role.Name
            //    //        })
            //    //})
            //    .Include(x=>x.SysUserRoles)
            //    .FirstOrDefaultAsync();


            var user = await _unitOfWork.Repository<SysUser, Guid>()
                .Query()
                .Include(u => u.SysUserRoles)
                .ThenInclude(ur => ur.Role)
                .ProjectTo<SysUserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Username == "Admin");

            return Ok(user);



        }

    }
}
