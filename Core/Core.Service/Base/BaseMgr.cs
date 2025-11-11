
namespace Core.Service.Base;

public abstract class BaseMgr
{
    public ServiceOperator ServiceOperator
    {
        get
        {
            var serviceOperator =
                (ServiceOperator)ScopedServiceProviderHolder.ScopedServiceProvider.GetService(typeof(ServiceOperator))!;

            return serviceOperator;
        }
    }
}