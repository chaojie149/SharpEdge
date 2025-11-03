using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberAccountUpdateModel
{
    #region Generated Properties
    public uint Uid { get; set; }

    public bool? Type { get; set; }

    public string? Pay { get; set; }

    public string? Content { get; set; }

    public long Money { get; set; }

    public string Time { get; set; } = null!;

    #endregion

}
