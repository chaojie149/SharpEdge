using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberDelCreateModel
{
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

    public decimal? Money { get; set; }

    public string? Emailcode { get; set; }

    public string? Mobilecode { get; set; }

    public bool Othercode { get; set; }

    public string? Passcode { get; set; }

    public string? RegKey { get; set; }

    public uint Score { get; set; }

    public uint? Jingyan { get; set; }

    public uint? Yaoqing { get; set; }

    public string? Band { get; set; }

    public int? Time { get; set; }

    public string Headimg { get; set; } = null!;

    public string? Wxid { get; set; }

    public uint? Typeid { get; set; }

    public sbyte? AutoUser { get; set; }

    public sbyte? Level { get; set; }

    public sbyte ShopPermission { get; set; }

    public sbyte OwinshopPermission { get; set; }

    public int Shoping { get; set; }

    public int Every { get; set; }

    public int Consumption { get; set; }

    public int Chongzhi { get; set; }

    #endregion

}
