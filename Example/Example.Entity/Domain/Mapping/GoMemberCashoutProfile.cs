using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberCashoutProfile
    : AutoMapper.Profile
{
    public GoMemberCashoutProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberCashout, Example.Entity.Domain.Models.GoMemberCashoutReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCashoutCreateModel, Example.Entity.Data.Entities.GoMemberCashout>();

        CreateMap<Example.Entity.Data.Entities.GoMemberCashout, Example.Entity.Domain.Models.GoMemberCashoutCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberCashout, Example.Entity.Domain.Models.GoMemberCashoutUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCashoutUpdateModel, Example.Entity.Data.Entities.GoMemberCashout>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCashoutReadModel, Example.Entity.Domain.Models.GoMemberCashoutUpdateModel>();

    }

}
