using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoLogistics
{
    public GoLogistics()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public string LogName { get; set; } = null!;

    public uint CreateTime { get; set; }

    public uint UpdateTime { get; set; }

    public byte IsState { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
