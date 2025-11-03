using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoVoteOptionCreateModel
{
    #region Generated Properties
    public int OptionId { get; set; }

    public int? VoteId { get; set; }

    public string? OptionTitle { get; set; }

    public uint? OptionNumber { get; set; }

    #endregion

}
