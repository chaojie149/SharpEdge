using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoWeixinPointRecord
{
    public GoWeixinPointRecord()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public int PrId { get; set; }

    public string Wxid { get; set; } = null!;

    public string PointName { get; set; } = null!;

    public int Num { get; set; }

    public int Lasttime { get; set; }

    public int Datelinie { get; set; }

    public uint Total { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
