// using System.Text.RegularExpressions;
// using Core.Service.GlobalConfig;
// using Core.WebApi.Response;
// using Core.WebApi.Storage;
// using log4net;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Configuration;
// using Newtonsoft.Json;
// using StackExchange.Redis.Extensions.Core.Abstractions;
//
// namespace Core.WebApi.Middleware;
//
// public class UseJwtMiddleware
// {
//     private static readonly ILog _logger = LogManager.GetLogger("AuthLog");
//     private readonly RequestDelegate _next;
//     private readonly IRedisClient _redisClient;
//
//
//     public UseJwtMiddleware(RequestDelegate next, IConfiguration configration, IRedisClient redisClient)
//     {
//         _redisClient = redisClient;
//         _next = next;
//     }
//
//     private Regex GetIgnoreUrlsReg(List<string> urls)
//     {
//         var regStrs = new List<string>();
//         foreach (var item in urls) regStrs.Add(string.Concat("^", item, ".*$"));
//
//         return new Regex(string.Join("|", regStrs));
//     }
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         if (GetIgnoreUrlsReg(AppGlobalSettings.AuthConfig.IgnoreUrls).Match(context.Request.Path).Success)
//             await Validate(context, false);
//         else
//             await Validate(context, true);
//     }
//
//
//     private async Task Validate(HttpContext context, bool ValidateToken)
//     {
//         // 验证 token 的情况下执行
//         if (ValidateToken &&
//             context.Request.Headers.TryGetValue(AppGlobalSettings.AuthConfig.HeadField, out var authValue))
//         {
//             var authstr = authValue.ToString();
//             if (AppGlobalSettings.AuthConfig.Prefix.Length > 0)
//             {
//                 if (!authstr.Contains(AppGlobalSettings.AuthConfig.Prefix))
//                 {
//                     context.Response.StatusCode = 401;
//                     context.Response.ContentType = "application/json";
//                     await context.Response.WriteAsync(
//                         JsonConvert.SerializeObject(ApiResponse<object>.Fail("无权限认证", 401)));
//                     _logger.Warn($"token [ {authstr} ] 认证失败");
//                     return; // 防止继续处理
//                 }
//
//                 authstr = authValue.ToString().Substring(AppGlobalSettings.AuthConfig.Prefix.Length,
//                     authValue.ToString().Length - AppGlobalSettings.AuthConfig.Prefix.Length);
//             }
//
//
//             var userExists = await _redisClient.Db0.ExistsAsync($"user:{authstr}");
//             var isAuth = userExists;
//
//             if (isAuth && userExists)
//             {
//                 await HandleAuth<UserStorage>(context, authstr, "user");
//             }
//             else
//             {
//                 if (ValidateToken && !context.Response.HasStarted)
//                 {
//                     context.Response.StatusCode = 401;
//                     context.Response.ContentType = "application/json";
//                     await context.Response.WriteAsync(
//                         JsonConvert.SerializeObject(ApiResponse<object>.Fail("无权限认证", 401)));
//                     return; // 防止继续处理
//                 }
//
//                 await _next(context);
//             }
//         }
//         else
//         {
//             if (ValidateToken && !context.Response.HasStarted)
//             {
//                 context.Response.StatusCode = 401;
//                 context.Response.ContentType = "application/json";
//                 await context.Response.WriteAsync(JsonConvert.SerializeObject(ApiResponse<object>.Fail("无权限认证", 401)));
//             }
//             else
//             {
//                 await _next(context);
//             }
//         }
//     }
//
//     private async Task HandleAuth<T>(HttpContext context, string authstr, string cachePrefix)
//         where T : Entity.Abstract.Storage
//     {
//         var key = $"{cachePrefix}:{authstr}";
//         Entity.Abstract.Storage userStorage = await _redisClient.Db0.GetAsync<T>(key);
//         var now = DateTimeUtil.GetTimeStamp();
//         _logger.Info(
//             $"当前签名时间 {now - userStorage.SignTime} + {TimeSpan.FromMinutes(AppGlobalSettings.AuthConfig.RenewalTime).TotalSeconds}" +
//             $"过期时间 {TimeSpan.FromMinutes(AppGlobalSettings.AuthConfig.Expire).TotalSeconds}");
//         if (now - userStorage.SignTime + TimeSpan.FromMinutes(AppGlobalSettings.AuthConfig.RenewalTime).TotalSeconds >
//             TimeSpan.FromMinutes(AppGlobalSettings.AuthConfig.Expire).TotalSeconds)
//         {
//             _logger.Info(
//                 $"续期 [ {authstr} ] [ {userStorage.UserName} ] [ {DateTimeUtil.GetDateTimeByTimeStamp(userStorage.SignTime)} ]");
//             userStorage.SignTime = DateTimeUtil.GetTimeStamp();
//
//             // 更新 Redis 键
//             await _redisClient.Db0.AddAsync($"{cachePrefix}:{userStorage.UserName}", authstr,
//                 TimeSpan.FromMinutes(AppGlobalSettings.AuthConfig.Expire));
//             await _redisClient.Db0.AddAsync($"{cachePrefix}:{authstr}", userStorage,
//                 TimeSpan.FromMinutes(AppGlobalSettings.AuthConfig.Expire));
//         }
//
//         await _next(context);
//     }
// }
//
// /// <summary>
// ///     扩展方法，将中间件暴露出去
// /// </summary>
// public static class UseUseJwtMiddlewareExtensions
// {
//     /// <summary>
//     ///     权限检查
//     /// </summary>
//     /// <param name="builder"></param>
//     /// <returns></returns>
//     public static IApplicationBuilder UseJwt(this IApplicationBuilder builder)
//     {
//         return builder.UseMiddleware<UseJwtMiddleware>();
//     }
// }