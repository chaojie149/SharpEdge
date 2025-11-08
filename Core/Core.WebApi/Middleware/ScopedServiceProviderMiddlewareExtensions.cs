using Microsoft.AspNetCore.Builder;

namespace Core.WebApi.Middleware;

public static class ScopedServiceProviderMiddlewareExtensions
{
    public static IApplicationBuilder UseScopedServiceProvider(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ScopedServiceProviderMiddleware>();
    }
}