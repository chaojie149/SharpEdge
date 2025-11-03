using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoEgglotterSpoilProfile
    : AutoMapper.Profile
{
    public GoEgglotterSpoilProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoEgglotterSpoil, Example.Entity.Domain.Models.GoEgglotterSpoilReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterSpoilCreateModel, Example.Entity.Data.Entities.GoEgglotterSpoil>();

        CreateMap<Example.Entity.Data.Entities.GoEgglotterSpoil, Example.Entity.Domain.Models.GoEgglotterSpoilCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoEgglotterSpoil, Example.Entity.Domain.Models.GoEgglotterSpoilUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterSpoilUpdateModel, Example.Entity.Data.Entities.GoEgglotterSpoil>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterSpoilReadModel, Example.Entity.Domain.Models.GoEgglotterSpoilUpdateModel>();

    }

}
