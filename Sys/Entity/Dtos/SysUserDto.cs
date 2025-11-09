namespace Sys.Entity.Dtos;

public sealed class SysUserDto
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
    /// 加密盐
    /// </summary>
    public string Salt { get; set; }

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

    /// <summary>
    /// 最后登录ip
    /// </summary>
    public string LastLoginIp { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTime LastLoginTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime? ModifyTime { get; set; }

    /// <summary>
    /// 修改人
    /// </summary>
    public string ModifyBy { get; set; }

    public List<SysRoleDto> Roles { get; set; }
}