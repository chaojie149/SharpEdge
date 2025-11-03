using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberGroupCreateModel
{
    #region Generated Properties
    public byte Groupid { get; set; }

    public string Name { get; set; } = null!;

    public uint JingyanStart { get; set; }

    public int JingyanEnd { get; set; }

    public string? Icon { get; set; }

    public string Type { get; set; } = null!;

    #endregion

}
