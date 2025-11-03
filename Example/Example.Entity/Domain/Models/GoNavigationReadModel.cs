using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoNavigationReadModel
{
    #region Generated Properties
    public ushort Cid { get; set; }

    public ushort Parentid { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Url { get; set; }

    public string? Status { get; set; }

    public ushort? Order { get; set; }

    #endregion

}
