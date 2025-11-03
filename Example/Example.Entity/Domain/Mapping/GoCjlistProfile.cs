using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCjlistProfile
    : AutoMapper.Profile
{
    public GoCjlistProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCjlist, Example.Entity.Domain.Models.GoCjlistReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCjlistCreateModel, Example.Entity.Data.Entities.GoCjlist>();

        CreateMap<Example.Entity.Data.Entities.GoCjlist, Example.Entity.Domain.Models.GoCjlistCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCjlist, Example.Entity.Domain.Models.GoCjlistUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCjlistUpdateModel, Example.Entity.Data.Entities.GoCjlist>();

        CreateMap<Example.Entity.Domain.Models.GoCjlistReadModel, Example.Entity.Domain.Models.GoCjlistUpdateModel>();

    }

}
