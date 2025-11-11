using Sys.Entity.Models;

namespace TestApi;
using Bogus;
using Microsoft.EntityFrameworkCore;

public static class TestUserDataGenerator
{
    public static async Task GenerateUsersAsync(SysDbContext db, int count = 10000)
    {
        // Faker 规则定义
        var faker = new Faker<SysUser>("zh_CN")
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Username, f => $"user_{f.UniqueIndex}") // 👈 唯一用户名
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.MobileArea, _ => 86)
            .RuleFor(u => u.MobilePhoneNumber, f => f.Phone.PhoneNumber("1##########"))
            .RuleFor(u => u.Password, _ => "123456") // 可以改成加密后的
            .RuleFor(u => u.Salt, _ => Guid.NewGuid().ToString("N").Substring(0, 6))
            .RuleFor(u => u.Status, f => f.Random.Int(0, 1))
            .RuleFor(u => u.LastLoginIp, f => f.Internet.Ip())
            .RuleFor(u => u.LastLoginTime, f => f.Date.RecentOffset(5).DateTime)
            .RuleFor(u => u.CreatedTime, f => f.Date.PastOffset(1).DateTime)
            .RuleFor(u => u.CreatedBy, f => "seed-script");

        // 批量生成
        var users = faker.Generate(count);

        // 写入数据库
        await db.SysUsers.AddRangeAsync(users);
        await db.SaveChangesAsync();

        Console.WriteLine($"✅ 已生成 {count} 条 sys_user 测试数据。");
    }
}
