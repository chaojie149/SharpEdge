using System.Reflection;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Sys.WebApi;

public  static class ControllerExtensions
{
    public static void AddSysControllers(
        this IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            })
            .AddApplicationPart(Assembly.GetExecutingAssembly())
            .AddControllersAsServices(); // 允许属性注入
    }



}