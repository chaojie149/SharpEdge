using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoVoteActiver
{
    public GoVoteActiver()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public int Id { get; set; }

    public int OptionId { get; set; }

    public int? VoteId { get; set; }

    public int? Userid { get; set; }

    public string? Ip { get; set; }

    public int? Subtime { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
