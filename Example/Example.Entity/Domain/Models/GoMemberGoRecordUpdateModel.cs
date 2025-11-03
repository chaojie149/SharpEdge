using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberGoRecordUpdateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public string? Code { get; set; }

    public byte? CodeTmp { get; set; }

    public string Username { get; set; } = null!;

    public string? Uphoto { get; set; }

    public uint Uid { get; set; }

    public uint Shopid { get; set; }

    public string Shopname { get; set; } = null!;

    public short Shopqishu { get; set; }

    public uint? Gonumber { get; set; }

    public string Goucode { get; set; } = null!;

    public long Moneycount { get; set; }

    public string Huode { get; set; } = null!;

    public string? PayType { get; set; }

    public string? Ip { get; set; }

    public string? Status { get; set; }

    public string Time { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string CompanyCode { get; set; } = null!;

    public uint CompanyMoney { get; set; }

    public string Address { get; set; } = null!;

    public string OrderPhone { get; set; } = null!;

    public sbyte ConfirmAddress { get; set; }

    #endregion

}
