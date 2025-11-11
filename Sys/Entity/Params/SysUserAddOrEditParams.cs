namespace Sys.Entity.Params;

public abstract class SysUserAddOrEditParams
{
    
    public string Id { get; set; }
    
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
    

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 区号
    /// </summary>
    public int? MobileArea { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string MobilePhoneNumber { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int? Status { get; set; }
}