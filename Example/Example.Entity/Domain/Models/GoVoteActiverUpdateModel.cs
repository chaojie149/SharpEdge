using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoVoteActiverUpdateModel
{
    #region Generated Properties
    public int Id { get; set; }

    public int OptionId { get; set; }

    public int? VoteId { get; set; }

    public int? Userid { get; set; }

    public string? Ip { get; set; }

    public int? Subtime { get; set; }

    #endregion

}
