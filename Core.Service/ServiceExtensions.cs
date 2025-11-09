using Autofac;
using Core.Service.Base;

namespace Core.Service;

public static class ServiceExtensions
{
    public static void AddCoreServices(
        this ContainerBuilder builder)
    {
        // add ServiceOperator as scoped
        builder.Register(r => new ServiceOperator()).InstancePerLifetimeScope();
    }
}