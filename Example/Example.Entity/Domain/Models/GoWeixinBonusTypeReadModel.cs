using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoWeixinBonusTypeReadModel
{
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

}
