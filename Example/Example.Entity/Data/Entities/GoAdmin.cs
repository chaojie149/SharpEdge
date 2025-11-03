using System;
using System.Collections.Generic;
using Core.Entity.Entities;
using Core.Persistent.Entities;

namespace Example.Entity.Data.Entities;

public partial class GoAdmin
{
    public GoAdmin()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public byte Uid { get; set; }

    public byte Mid { get; set; }

    public string Username { get; set; } = null!;

    public string Userpass { get; set; } = null!;

    public string? Useremail { get; set; }

    public uint? Addtime { get; set; }

    public uint? Logintime { get; set; }

    public string? Loginip { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
