using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoVoteOption
{
    public GoVoteOption()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public int OptionId { get; set; }

    public int? VoteId { get; set; }

    public string? OptionTitle { get; set; }

    public uint? OptionNumber { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
