using System;
using System.Collections.Generic;

namespace Example.Entity.Data.Entities;

public partial class SignIn
{
    public SignIn()
    {
        #region Generated Constructor
        #endregion
    }

    #region Generated Properties
    public int Id { get; set; }

    public int Uid { get; set; }

    public DateOnly SignDate { get; set; }

    public int Points { get; set; }

    public int CreateTime { get; set; }

    #endregion

    #region Generated Relationships
    #endregion

}
