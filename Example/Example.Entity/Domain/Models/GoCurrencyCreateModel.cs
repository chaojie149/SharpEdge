using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoCurrencyCreateModel
{
    #region Generated Properties
    public int Id { get; set; }

    public string? Title { get; set; }

    public string Code { get; set; } = null!;

    public string SymbolLeft { get; set; } = null!;

    public string SymbolRight { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Unit { get; set; } = null!;

    #endregion

}
