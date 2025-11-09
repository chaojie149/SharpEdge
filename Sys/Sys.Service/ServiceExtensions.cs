using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Core.Service;
using Core.Service.Base;

namespace Sys.Service;

public static class ServiceExtensions
{
    public static void AddSysServices(
        this ContainerBuilder builder)
    {
        // register service
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(x => x.IsSubclassOf(typeof(BaseMgr)))
            .AsImplementedInterfaces().InstancePerLifetimeScope()
            .PropertiesAutowired().EnableInterfaceInterceptors();
    }
    
    
    public static void AddSysServiceAutoMapper(this ContainerBuilder builder)
    {
        // register automapper
        builder.RegisterAutoMapper(Assembly.GetExecutingAssembly());
    }
}