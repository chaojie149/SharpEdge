using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoWeixinPointUpdateModel
{
    #region Generated Properties
    public uint PointId { get; set; }

    public string PointName { get; set; } = null!;

    public uint PointValue { get; set; }

    public int PointNum { get; set; }

    public string Autoload { get; set; } = null!;

    #endregion

}
