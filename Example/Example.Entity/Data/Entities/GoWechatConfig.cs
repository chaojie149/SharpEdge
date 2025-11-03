using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoWechatConfig
{
    public GoWechatConfig()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public string Appid { get; set; } = null!;

    public string Appsecret { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public uint Dateline { get; set; }

    public string Menu { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
