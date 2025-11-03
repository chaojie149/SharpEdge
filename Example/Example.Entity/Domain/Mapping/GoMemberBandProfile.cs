using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberBandProfile
    : AutoMapper.Profile
{
    public GoMemberBandProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberBand, Example.Entity.Domain.Models.GoMemberBandReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBandCreateModel, Example.Entity.Data.Entities.GoMemberBand>();

        CreateMap<Example.Entity.Data.Entities.GoMemberBand, Example.Entity.Domain.Models.GoMemberBandCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberBand, Example.Entity.Domain.Models.GoMemberBandUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBandUpdateModel, Example.Entity.Data.Entities.GoMemberBand>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBandReadModel, Example.Entity.Domain.Models.GoMemberBandUpdateModel>();

    }

}
