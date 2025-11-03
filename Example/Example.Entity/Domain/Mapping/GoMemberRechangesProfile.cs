using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberRechangesProfile
    : AutoMapper.Profile
{
    public GoMemberRechangesProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberRechanges, Example.Entity.Domain.Models.GoMemberRechangesReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRechangesCreateModel, Example.Entity.Data.Entities.GoMemberRechanges>();

        CreateMap<Example.Entity.Data.Entities.GoMemberRechanges, Example.Entity.Domain.Models.GoMemberRechangesCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberRechanges, Example.Entity.Domain.Models.GoMemberRechangesUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRechangesUpdateModel, Example.Entity.Data.Entities.GoMemberRechanges>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRechangesReadModel, Example.Entity.Domain.Models.GoMemberRechangesUpdateModel>();

    }

}
