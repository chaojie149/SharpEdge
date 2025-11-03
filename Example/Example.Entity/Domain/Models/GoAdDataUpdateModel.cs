using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoAdDataUpdateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public uint Aid { get; set; }

    public string Title { get; set; } = null!;

    public string? Type { get; set; }

    public string? Content { get; set; }

    public bool? Checked { get; set; }

    public uint Addtime { get; set; }

    public uint Endtime { get; set; }

    #endregion

}
