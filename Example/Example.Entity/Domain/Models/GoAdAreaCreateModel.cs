using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoAdAreaCreateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public string Title { get; set; } = null!;

    public ushort? Width { get; set; }

    public ushort? Height { get; set; }

    public string? Des { get; set; }

    public bool? Checked { get; set; }

    #endregion

}
