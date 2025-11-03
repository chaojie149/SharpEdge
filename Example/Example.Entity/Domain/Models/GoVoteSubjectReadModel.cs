using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoVoteSubjectReadModel
{
    #region Generated Properties
    public int VoteId { get; set; }

    public string? VoteTitle { get; set; }

    public int? VoteStarttime { get; set; }

    public int? VoteEndtime { get; set; }

    public int? VoteSendtime { get; set; }

    public string? VoteDescription { get; set; }

    public bool? VoteAllowview { get; set; }

    public bool? VoteAllowguest { get; set; }

    public int? VoteInterval { get; set; }

    public bool? VoteEnabled { get; set; }

    public int? VoteNumber { get; set; }

    #endregion

}
