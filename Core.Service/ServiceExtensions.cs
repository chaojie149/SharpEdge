using Autofac;
using Core.Service.Base;
using Microsoft.AspNetCore.Http;

namespace Core.Service;

public static class ServiceExtensions
{
    public static void AddCoreServices(this ContainerBuilder builder)
    {
        // 注册 IHttpContextAccessor（若未注册）
        builder.RegisterType<HttpContextAccessor>()
            .As<IHttpContextAccessor>()
            .SingleInstance();

        // 注册 ServiceOperator（让 Autofac 自动注入 IHttpContextAccessor）
        builder.RegisterType<ServiceOperator>()
            .AsSelf()
            .InstancePerLifetimeScope();
    }
}