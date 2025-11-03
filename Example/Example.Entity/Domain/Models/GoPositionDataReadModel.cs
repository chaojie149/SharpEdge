using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoPositionDataReadModel
{
    #region Generated Properties
    public uint Id { get; set; }

    public uint ConId { get; set; }

    public byte ModId { get; set; }

    public string ModName { get; set; } = null!;

    public uint PosId { get; set; }

    public string PosData { get; set; } = null!;

    public uint PosOrder { get; set; }

    public uint PosTime { get; set; }

    #endregion

}
