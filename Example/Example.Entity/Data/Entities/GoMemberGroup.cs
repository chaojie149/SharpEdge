using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoMemberGroup
{
    public GoMemberGroup()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public byte Groupid { get; set; }

    public string Name { get; set; } = null!;

    public uint JingyanStart { get; set; }

    public int JingyanEnd { get; set; }

    public string? Icon { get; set; }

    public string Type { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
