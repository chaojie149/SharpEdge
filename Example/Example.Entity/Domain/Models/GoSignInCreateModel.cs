using System;
using System.Collections.Generic;

namespace Example.Entity.Domain.Models;

public partial class GoSignInCreateModel
{
    #region Generated Properties
    public int Id { get; set; }

    public int Uid { get; set; }

    public DateOnly SignDate { get; set; }

    public int Points { get; set; }

    public int CreateTime { get; set; }

    #endregion

}
