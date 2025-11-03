using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoMemberAddmoneyRecord
{
    public GoMemberAddmoneyRecord()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public uint Uid { get; set; }

    public string Code { get; set; } = null!;

    public decimal Money { get; set; }

    public string PayType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int Time { get; set; }

    public uint Score { get; set; }

    public string? Scookies { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
