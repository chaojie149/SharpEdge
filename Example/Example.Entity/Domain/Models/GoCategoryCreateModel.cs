using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoCategoryCreateModel
{
    #region Generated Properties
    public ushort Cateid { get; set; }

    public string? Language { get; set; }

    public short? Parentid { get; set; }

    public sbyte Channel { get; set; }

    public bool? Model { get; set; }

    public string? Name { get; set; }

    public string? Catdir { get; set; }

    public string PicUrl { get; set; } = null!;

    public string? Url { get; set; }

    public string? Info { get; set; }

    public ushort? Order { get; set; }

    #endregion

}
