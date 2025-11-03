using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoCzk
{
    public GoCzk()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public int Id { get; set; }

    public string Czknum { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Mianzhi { get; set; }

    public sbyte Status { get; set; }

    public sbyte Type { get; set; }

    public string Ewm { get; set; } = null!;

    public string Address { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
