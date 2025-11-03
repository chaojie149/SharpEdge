using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoMobileVerify
{
    public GoMobileVerify()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public string? Mobile { get; set; }

    public string Verify { get; set; } = null!;

    public string Time { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
