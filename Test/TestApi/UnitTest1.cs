using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using Sys.Entity.Models;
using TestApi;
using Xunit;
using Assert = Xunit.Assert;

public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    // private readonly HttpClient _client;
    //
    // public AuthControllerTests(WebApplicationFactory<Program> factory)
    // {
    //     _client = factory.CreateClient();
    // }
    //
    // [Fact]
    // public async Task Login_Refresh_Logout_Workflow()
    // {
    //     // === 1. 登录 ===
    //     var loginBody = new
    //     {
    //         username = "admin",
    //         password = "P@ssw0rd"
    //     };
    //
    //     var response = await _client.PostAsync("http://localhost:5215/auth/login",
    //         new StringContent(JsonSerializer.Serialize(loginBody), Encoding.UTF8, "application/json"));
    //     response.EnsureSuccessStatusCode();
    //
    //     var json = await response.Content.ReadAsStringAsync();
    //     var result = JsonDocument.Parse(json).RootElement;
    //     var token = result.GetProperty("token").GetString();
    //     var refresh = result.GetProperty("refreshToken").GetString();
    //
    //     Assert.NotNull(token);
    //     Assert.NotNull(refresh);
    //
    //     // === 2. 刷新 ===
    //     _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //     var refreshResponse = await _client.PostAsync($"/auth/refreshToken?refreshToken={refresh}", null);
    //     refreshResponse.EnsureSuccessStatusCode();
    //
    //     // === 3. 登出 ===
    //     var logoutResponse = await _client.PostAsync("http://localhost:5215/auth/logout", null);
    //     logoutResponse.EnsureSuccessStatusCode();
    // }


    [Test]
    public async Task gen()
    {
        using var db = new SysDbContext(
            new DbContextOptionsBuilder<SysDbContext>()
                .UseMySql("Server=localhost;Port=3306;Database=net_core_pro;User=root;Password=root;Charset=utf8mb4;SslMode=None;AllowPublicKeyRetrieval=True;",
                    new MySqlServerVersion(new Version(8, 0, 33)))
                .Options);

        await TestUserDataGenerator.GenerateUsersAsync(db,10000);
    }
}