using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoWeixinPointRecordCreateModel
{
    #region Generated Properties
    public int PrId { get; set; }

    public string Wxid { get; set; } = null!;

    public string PointName { get; set; } = null!;

    public int Num { get; set; }

    public int Lasttime { get; set; }

    public int Datelinie { get; set; }

    public uint Total { get; set; }

    #endregion

}
