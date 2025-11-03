using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoWxchCfgCreateModel
{
    #region Generated Properties
    public uint CfgId { get; set; }

    public string CfgName { get; set; } = null!;

    public string CfgValue { get; set; } = null!;

    public string Autoload { get; set; } = null!;

    #endregion

}
