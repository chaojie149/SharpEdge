using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoCjcodeReadModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public uint Code { get; set; }

    public string Scenename { get; set; } = null!;

    public string Ticket { get; set; } = null!;

    public uint Time { get; set; }

    public uint Total { get; set; }

    public uint Nownum { get; set; }

    #endregion

}
