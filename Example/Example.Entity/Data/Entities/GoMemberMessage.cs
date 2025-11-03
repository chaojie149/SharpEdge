using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoMemberMessage
{
    public GoMemberMessage()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public uint Uid { get; set; }

    public bool? Type { get; set; }

    public uint? Sendid { get; set; }

    public string? Sendname { get; set; }

    public string? Content { get; set; }

    public int? Time { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
