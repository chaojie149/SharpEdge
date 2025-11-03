using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoQqsetCreateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public string? Qq { get; set; }

    public string? Name { get; set; }

    public string Type { get; set; } = null!;

    public string? Qqurl { get; set; }

    public string Full { get; set; } = null!;

    public string? Province { get; set; }

    public string? City { get; set; }

    public string? County { get; set; }

    public string? Subtime { get; set; }

    #endregion

}
