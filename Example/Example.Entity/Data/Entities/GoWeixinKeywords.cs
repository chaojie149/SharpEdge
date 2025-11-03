using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoWeixinKeywords
{
    public GoWeixinKeywords()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string Keyword { get; set; } = null!;

    public byte Type { get; set; }

    public string Contents { get; set; } = null!;

    public string Pic { get; set; } = null!;

    public string PicTit { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public string PicUrl { get; set; } = null!;

    public uint Count { get; set; }

    public byte Status { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
