using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberRechangeProfile
    : AutoMapper.Profile
{
    public GoMemberRechangeProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberRechange, Example.Entity.Domain.Models.GoMemberRechangeReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRechangeCreateModel, Example.Entity.Data.Entities.GoMemberRechange>();

        CreateMap<Example.Entity.Data.Entities.GoMemberRechange, Example.Entity.Domain.Models.GoMemberRechangeCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberRechange, Example.Entity.Domain.Models.GoMemberRechangeUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRechangeUpdateModel, Example.Entity.Data.Entities.GoMemberRechange>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRechangeReadModel, Example.Entity.Domain.Models.GoMemberRechangeUpdateModel>();

    }

}
