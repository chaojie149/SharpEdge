using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberRecodesCreateModel
{
    #region Generated Properties
    public int Id { get; set; }

    public int Rebateid { get; set; }

    public uint Uid { get; set; }

    public bool Type { get; set; }

    public string Content { get; set; } = null!;

    public int? Shopid { get; set; }

    public decimal Money { get; set; }

    public string Time { get; set; } = null!;

    public decimal Ygmoney { get; set; }

    public int? Cashoutid { get; set; }

    #endregion

}
