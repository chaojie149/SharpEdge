using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberRechangesCreateModel
{
    #region Generated Properties
    public int Id { get; set; }

    public int PayId { get; set; }

    public float Num { get; set; }

    public string Oid { get; set; } = null!;

    public int Uid { get; set; }

    public DateTime Time { get; set; }

    public int Type { get; set; }

    #endregion

}
