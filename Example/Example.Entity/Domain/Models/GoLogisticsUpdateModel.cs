using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoLogisticsUpdateModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public string LogName { get; set; } = null!;

    public uint CreateTime { get; set; }

    public uint UpdateTime { get; set; }

    public byte IsState { get; set; }

    #endregion

}
