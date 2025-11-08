namespace Core.WebApi;

public abstract class ScopedServiceProviderHolder
{
    private static readonly AsyncLocal<IServiceProvider> ServiceProviderContext = new();

    public static IServiceProvider ScopedServiceProvider
    {
        get
        {
            if (ServiceProviderContext.Value == null)
                throw new InvalidOperationException(
                    "ServiceProvider has not been set!"
                );
            return ServiceProviderContext.Value;
        }

        set => ServiceProviderContext.Value = value;
    }
}