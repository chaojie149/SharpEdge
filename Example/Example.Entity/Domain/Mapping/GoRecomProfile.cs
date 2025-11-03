using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoRecomProfile
    : AutoMapper.Profile
{
    public GoRecomProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoRecom, Example.Entity.Domain.Models.GoRecomReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoRecomCreateModel, Example.Entity.Data.Entities.GoRecom>();

        CreateMap<Example.Entity.Data.Entities.GoRecom, Example.Entity.Domain.Models.GoRecomCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoRecom, Example.Entity.Domain.Models.GoRecomUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoRecomUpdateModel, Example.Entity.Data.Entities.GoRecom>();

        CreateMap<Example.Entity.Domain.Models.GoRecomReadModel, Example.Entity.Domain.Models.GoRecomUpdateModel>();

    }

}
