using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class GoQuanzi
{
    public GoQuanzi()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public byte Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Img { get; set; }

    public uint? Chengyuan { get; set; }

    public uint? Tiezi { get; set; }

    public uint Guanli { get; set; }

    public ushort? Jinhua { get; set; }

    public string? Jianjie { get; set; }

    public string? Gongao { get; set; }

    public string? Jiaru { get; set; }

    public string? Glfatie { get; set; }

    public int Time { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
