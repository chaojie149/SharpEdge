using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoPayReadModel
{
    #region Generated Properties
    public uint PayId { get; set; }

    public string PayName { get; set; } = null!;

    public string? PayBank { get; set; }

    public string PayClass { get; set; } = null!;

    public sbyte PayType { get; set; }

    public string? PayThumb { get; set; }

    public string? PayDes { get; set; }

    public sbyte PayStart { get; set; }

    public string? PayKey { get; set; }

    public byte PayMobile { get; set; }

    #endregion

}
