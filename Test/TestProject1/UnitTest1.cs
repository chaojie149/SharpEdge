using Core.Service.Util;
using Core.WebApi.Extensions;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    
    [Test]
    public void Test1()
    {
        Console.WriteLine("P@ssw0rd".EncryptDES("C5ABA9E202D94C43A3CA66002BF77FAF"));
        Console.WriteLine(Guid.NewGuid() + "=" + DateTimeUtil.GetTimeStamp());
        Console.WriteLine(DateTimeUtil.GetDateTimeByTimeStamp(1724129820));
        var s = "Sys_user";
        Console.WriteLine(s.Split("_")[1]);
    }

    public static bool MatchPath(string route, string reqPath)
    {
        // Helper method to remove the part after the last '/'
        string RemoveAfterLastSlash(string path)
        {
            var lastSlashIndex = path.LastIndexOf('/');
            if (lastSlashIndex == -1) return path; // No slashes, return the whole string
            return path.Substring(0, lastSlashIndex);
        }

        // Remove the part after the last '/' from reqPath
        var reqPathTrimmed = RemoveAfterLastSlash(reqPath);

        // Remove the part after the last '/' from route
        var routeTrimmed = RemoveAfterLastSlash(route);

        // Replace ':parameter' with an empty string in the routeTrimmed
        routeTrimmed = routeTrimmed.Replace(":", "");

        // Compare the trimmed request path with the modified route path
        return string.Equals(reqPathTrimmed, routeTrimmed, StringComparison.OrdinalIgnoreCase);
    }

    [Test]
    public void Test2()
    {
        var route = "/pms/role/user/:roleId";
        var reqPath = "/pms/role1/user/2";
        var isMatch3 = MatchPath(route, reqPath);
        Console.WriteLine(isMatch3); // Should output: False
        //IRouter Route = new Route(this,route);
    }
    
    [Test]
    public void GetGUID()
    {
       
        Console.WriteLine(Guid.CreateVersion7()); // Should output: False
        //IRouter Route = new Route(this,route);
    }
    
    
    
    
    [Test]
    public void Password()
    {
       
        Console.WriteLine(PasswordHelper.HashPassword("P@ssw0rd","C5ABA9E202D94C43A3CA66002BF77FAF")); // Should output: False
        //IRouter Route = new Route(this,route);
    }
}