using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoCardRecharge
{
    public GoCardRecharge()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public uint? Uid { get; set; }

    public ulong? Money { get; set; }

    public string? Code { get; set; }

    public string? Codepwd { get; set; }

    public string? Isrepeat { get; set; }

    public int? Rechargecount { get; set; }

    public int? Maxrechargecout { get; set; }

    public int? Rechargetime { get; set; }

    public int? Time { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
