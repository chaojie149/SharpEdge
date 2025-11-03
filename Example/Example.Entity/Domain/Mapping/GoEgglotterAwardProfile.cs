using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoEgglotterAwardProfile
    : AutoMapper.Profile
{
    public GoEgglotterAwardProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoEgglotterAward, Example.Entity.Domain.Models.GoEgglotterAwardReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterAwardCreateModel, Example.Entity.Data.Entities.GoEgglotterAward>();

        CreateMap<Example.Entity.Data.Entities.GoEgglotterAward, Example.Entity.Domain.Models.GoEgglotterAwardCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoEgglotterAward, Example.Entity.Domain.Models.GoEgglotterAwardUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterAwardUpdateModel, Example.Entity.Data.Entities.GoEgglotterAward>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterAwardReadModel, Example.Entity.Domain.Models.GoEgglotterAwardUpdateModel>();

    }

}
