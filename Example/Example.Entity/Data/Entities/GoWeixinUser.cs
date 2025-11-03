using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoWeixinUser
{
    public GoWeixinUser()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Uid { get; set; }

    public byte Subscribe { get; set; }

    public string Wxid { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public byte Sex { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public uint Time { get; set; }

    public uint Typeid { get; set; }

    public string Headimgurl { get; set; } = null!;

    public uint SubscribeTime { get; set; }

    public string Localimgurl { get; set; } = null!;

    public ushort Setp { get; set; }

    public string Uname { get; set; } = null!;

    public string Coupon { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
