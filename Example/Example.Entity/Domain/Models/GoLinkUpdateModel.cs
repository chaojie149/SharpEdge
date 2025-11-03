using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoLinkUpdateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public byte Type { get; set; }

    public string Name { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string Url { get; set; } = null!;

    #endregion

}
