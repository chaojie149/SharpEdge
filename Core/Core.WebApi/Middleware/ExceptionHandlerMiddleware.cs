using System.Net;
using Core.WebApi.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Localization;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Core.WebApi.Middleware;

/// <summary>
/// 全局异常处理中间件
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>();

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
       
        catch (AuthenticationFailureException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized, ex.Message);
        }
      
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode, string message)
    {
        // 避免重复写入响应
        if (context.Response.HasStarted)
        {
            _logger.Warning("Response already started, cannot handle exception: {Message}", ex.Message);
            return;
        }

        // 记录日志（统一写入 errinfo-.log）
        _logger.Error(ex,
            "请求异常 [{StatusCode}] {Method} {Path} | IP: {Ip}",
            (int)statusCode,
            context.Request.Method,
            $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
            context.Connection.RemoteIpAddress?.ToString());

        // 构造返回内容
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;
        response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
        response.Headers["Pragma"] = "no-cache";
        response.Headers["Expires"] = "0";

        var result = ApiResponse<object>.Fail(message, [ex.Message], (int)statusCode);
        await response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}
