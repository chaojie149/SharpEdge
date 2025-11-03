using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMobileVerifyReadModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public string? Mobile { get; set; }

    public string Verify { get; set; } = null!;

    public string Time { get; set; } = null!;

    #endregion

}
