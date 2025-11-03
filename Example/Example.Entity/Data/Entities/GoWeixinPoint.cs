using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoWeixinPoint
{
    public GoWeixinPoint()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint PointId { get; set; }

    public string PointName { get; set; } = null!;

    public uint PointValue { get; set; }

    public int PointNum { get; set; }

    public string Autoload { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
