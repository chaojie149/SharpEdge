using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoArticle
{
    public GoArticle()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public uint Id { get; set; }

    public string Cateid { get; set; } = null!;

    public string? Author { get; set; }

    public string Title { get; set; } = null!;

    public string? TitleStyle { get; set; }

    public string? Thumb { get; set; }

    public string? Picarr { get; set; }

    public string? Keywords { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }

    public uint? Hit { get; set; }

    public byte? Order { get; set; }

    public uint? Posttime { get; set; }

    public string Language { get; set; } = null!;

    #endregion

    #region Generated Relationships
    #endregion

}
