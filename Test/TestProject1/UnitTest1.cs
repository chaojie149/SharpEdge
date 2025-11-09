using System.Security.Claims;
using Core.Service.Config;
using Core.Service.GlobalConfig;
using Core.Service.Util;
using Core.WebApi.Extensions;
using Core.WebApi.Jwt;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        AppGlobalSettings.AuthConfig = new AuthConfig
        {
            SecretKey = "C5ABA9E202D94C43A3CA66002BF77FAF",
            Issuer = "SharpEdge",
            Audience = "FastNetCoreProUser",
            Expire = 60
        };
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
    public void VeryToken()
    {
       
      IJwtService jwtService = new JwtService();


      ClaimsPrincipal? claimsPrincipal = jwtService.ValidateToken(
          "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW4iLCJ1aWQiOiIwMTlhNjJlMC03NWI1LTcwNjgtOTQzYi1lZTQ5ZjkyYTMyYmIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJTdXBlckFkbWluIiwibmJmIjoxNzYyNjkwMDE2LCJleHAiOjE3NjI2OTcyMTYsImlzcyI6IlNoYXJwRWRnZSIsImF1ZCI6IkZhc3ROZXRDb3JlUHJvVXNlciJ9.HOZI_qNCGEzs7vzq2Oqz8Rn-3_t2cYBm20sUHMHyrx0");
         
         Console.WriteLine(claimsPrincipal.Identity.Name);
         
         foreach (var claimsPrincipalClaim in claimsPrincipal.Claims)
         {
             Console.WriteLine($"{claimsPrincipalClaim.Type} {claimsPrincipalClaim.Value}");
         }
         
         foreach (var claimsPrincipalIdentity in claimsPrincipal.Identities)
         {
             Console.WriteLine($"-- {claimsPrincipalIdentity.Name}");

         }
         
         Console.WriteLine($"UID {claimsPrincipal.Claims .FirstOrDefault(x => x.Type.Equals("uid"))?.Value}");
    }

    
    
    [Test]
    public void Password()
    {
       
        Console.WriteLine(PasswordHelper.HashPassword("P@ssw0rd","C5ABA9E202D94C43A3CA66002BF77FAF")); // Should output: False
        //IRouter Route = new Route(this,route);
    }
}