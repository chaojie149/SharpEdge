using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoAdminUpdateModel
{
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

}
