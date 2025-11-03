using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoLink
{
    public GoLink()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public byte Type { get; set; }

    public string Name { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string Url { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
