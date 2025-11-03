using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoMember
{
    public GoMember()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Uid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? Password { get; set; }

    public string? UserIp { get; set; }

    public string? Img { get; set; }

    public string? Qianming { get; set; }

    public byte? Groupid { get; set; }

    public string? Addgroup { get; set; }

    public ulong? Money { get; set; }

    public string? Emailcode { get; set; }

    public string? Mobilecode { get; set; }

    public bool Othercode { get; set; }

    public string? Passcode { get; set; }

    public string? RegKey { get; set; }

    public uint Score { get; set; }

    public uint? Jingyan { get; set; }

    public uint? Yaoqing1 { get; set; }

    public string? Yaoqing1name { get; set; }

    public uint? Yaoqing2 { get; set; }

    public string? Yaoqing2name { get; set; }

    public string? Band { get; set; }

    public int? Time { get; set; }

    public string Headimg { get; set; } = null!;

    public string? Wxid { get; set; }

    public uint? Typeid { get; set; }

    public string? Retype { get; set; }

    public sbyte? AutoUser { get; set; }

    public sbyte? Level { get; set; }

    public sbyte ShopPermission { get; set; }

    public sbyte OwinshopPermission { get; set; }

    public string? Facebookid { get; set; }

    public string? Gooleid { get; set; }

    public string? Every { get; set; }

    public string? Consumption { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
