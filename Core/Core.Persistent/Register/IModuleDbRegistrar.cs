using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistent.Register;

public interface IModuleDbRegistrar
{
    void Register(IServiceCollection services, IConfiguration configuration);
}