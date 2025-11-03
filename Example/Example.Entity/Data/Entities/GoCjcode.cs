using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoCjcode
{
    public GoCjcode()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public uint Code { get; set; }

    public string Scenename { get; set; } = null!;

    public string Ticket { get; set; } = null!;

    public uint Time { get; set; }

    public uint Total { get; set; }

    public uint Nownum { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
