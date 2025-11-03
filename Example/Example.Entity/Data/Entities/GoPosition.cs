using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoPosition
{
    public GoPosition()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint PosId { get; set; }

    public byte PosModel { get; set; }

    public string PosName { get; set; } = null!;

    public byte PosNum { get; set; }

    public byte PosMaxnum { get; set; }

    public byte PosThisNum { get; set; }

    public uint PosTime { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
