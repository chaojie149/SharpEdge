using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoMemberZpCreateModel
{
    #region Generated Properties
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public string Money { get; set; } = null!;

    public string Img { get; set; } = null!;

    public byte Grade { get; set; }

    public sbyte Probability { get; set; }

    public sbyte Type { get; set; }

    public sbyte? Ren { get; set; }

    #endregion

}
