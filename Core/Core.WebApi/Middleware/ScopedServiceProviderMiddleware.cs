using Microsoft.AspNetCore.Http;

namespace Core.WebApi.Middleware;

public class ScopedServiceProviderMiddleware
{
    private readonly RequestDelegate _next;

    public ScopedServiceProviderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IServiceProvider serviceProvider)
    {
        ScopedServiceProviderHolder.ScopedServiceProvider = serviceProvider;

        await _next(httpContext);
    }
}