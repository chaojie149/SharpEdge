using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoPositionUpdateModel
{
    #region Generated Properties
    public uint PosId { get; set; }

    public byte PosModel { get; set; }

    public string PosName { get; set; } = null!;

    public byte PosNum { get; set; }

    public byte PosMaxnum { get; set; }

    public byte PosThisNum { get; set; }

    public uint PosTime { get; set; }

    #endregion

}
