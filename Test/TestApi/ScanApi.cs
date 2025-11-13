using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Sys.Entity.Models;
using Xunit;

namespace TestApi
{
    public class ApiScannerTests
    {
        private readonly SysDbContext _db;

        public ApiScannerTests()
        {
            var options = new DbContextOptionsBuilder<SysDbContext>()
                .UseMySql("server=localhost;database=net_core_pro;user=root;password=root;",
                    new MySqlServerVersion(new Version(8, 0, 36)))
                .Options;

            _db = new SysDbContext(options);
        }

        [Fact]
        public async Task ScanAndInsertAllControllersAsync()
        {
            var assembly = Assembly.Load("Sys.WebApi"); // 替换为你的 WebApi 程序集名
            var controllerTypes = assembly.GetTypes()
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t) &&
                            t.GetCustomAttribute<ApiControllerAttribute>() != null)
                .ToList();

            foreach (var controller in controllerTypes)
            {
                var moduleName = controller.Name.Replace("Controller", "");
                var routeAttr = controller.GetCustomAttribute<RouteAttribute>();
                var baseRoute = routeAttr?.Template?.TrimEnd('/') ?? "[controller]";

                var actions = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Where(m => m.GetCustomAttributes().OfType<HttpMethodAttribute>().Any())
                    .ToList();

                foreach (var action in actions)
                {
                    var httpAttr = action.GetCustomAttributes<HttpMethodAttribute>().FirstOrDefault();
                    var httpMethod = httpAttr?.HttpMethods.FirstOrDefault() ?? "GET";
                    var actionRoute = httpAttr?.Template ?? string.Empty;

                    var fullPath = $"{baseRoute}/{actionRoute}".Replace("//", "/");
                    fullPath = fullPath.Replace("[controller]", moduleName);

                    // ✅ 提取 [EndpointSummary("xxx")] 的值
                    var endpointSummary = action
                        .GetCustomAttributes()
                        .FirstOrDefault(a => a.GetType().Name == "EndpointSummaryAttribute");

                    string displayName = action.Name;
                    if (endpointSummary != null)
                    {
                        // 尝试反射获取构造参数或属性中的值
                        var summaryProp = endpointSummary.GetType()
                            .GetProperty("Summary") ?? endpointSummary.GetType().GetProperty("Value");
                        if (summaryProp != null)
                        {
                            displayName = summaryProp.GetValue(endpointSummary)?.ToString() ?? displayName;
                        }
                        else
                        {
                            // 兼容构造函数参数
                            var ctorArg = endpointSummary.GetType()
                                .GetConstructors()
                                .FirstOrDefault()?
                                .GetParameters()
                                .FirstOrDefault();

                            if (ctorArg != null)
                            {
                                var args = endpointSummary.GetType()
                                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .FirstOrDefault();
                                if (args != null)
                                    displayName = args.GetValue(endpointSummary)?.ToString() ?? displayName;
                            }
                        }
                    }

                    // 检查是否已存在，避免重复插入
                    if (!_db.SysApis.Any(a => a.Path == fullPath && a.Method == httpMethod))
                    {
                        var entity = new SysApi
                        {
                            Id = Guid.NewGuid(),
                            Name = displayName, // ✅ 如果有 EndpointSummary，用注解值
                            Module = moduleName,
                            Method = httpMethod,
                            Path = fullPath,
                            PermissionCode = $"{moduleName}:{action.Name}",
                            CreatedBy = "UnitTest",
                            CreatedTime = DateTime.Now
                        };

                        _db.SysApis.Add(entity);
                    }
                }
            }

            await _db.SaveChangesAsync();
        }
    }
}
