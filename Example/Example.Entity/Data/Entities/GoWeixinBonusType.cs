using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoWeixinBonusType
{
    public GoWeixinBonusType()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public ushort TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public decimal TypeMoney { get; set; }

    public byte SendType { get; set; }

    public int SendStartDate { get; set; }

    public int SendEndDate { get; set; }

    public uint Total { get; set; }

    public uint Getnum { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
