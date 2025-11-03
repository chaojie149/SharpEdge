using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCzkProfile
    : AutoMapper.Profile
{
    public GoCzkProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCzk, Example.Entity.Domain.Models.GoCzkReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCzkCreateModel, Example.Entity.Data.Entities.GoCzk>();

        CreateMap<Example.Entity.Data.Entities.GoCzk, Example.Entity.Domain.Models.GoCzkCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCzk, Example.Entity.Domain.Models.GoCzkUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCzkUpdateModel, Example.Entity.Data.Entities.GoCzk>();

        CreateMap<Example.Entity.Domain.Models.GoCzkReadModel, Example.Entity.Domain.Models.GoCzkUpdateModel>();

    }

}
