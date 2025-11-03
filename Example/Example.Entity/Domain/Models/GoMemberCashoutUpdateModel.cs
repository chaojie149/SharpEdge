using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberCashoutUpdateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public uint Uid { get; set; }

    public string Username { get; set; } = null!;

    public string Bankname { get; set; } = null!;

    public string Branch { get; set; } = null!;

    public decimal Money { get; set; }

    public string Time { get; set; } = null!;

    public string Banknumber { get; set; } = null!;

    public string Linkphone { get; set; } = null!;

    public sbyte Auditstatus { get; set; }

    public decimal Procefees { get; set; }

    public string Reviewtime { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Oid { get; set; } = null!;

    #endregion

}
