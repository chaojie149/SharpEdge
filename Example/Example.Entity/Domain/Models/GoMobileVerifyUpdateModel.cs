using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMobileVerifyUpdateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public string? Mobile { get; set; }

    public string Verify { get; set; } = null!;

    public string Time { get; set; } = null!;

    #endregion

}
