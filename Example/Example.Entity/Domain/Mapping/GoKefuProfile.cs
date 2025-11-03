using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoKefuProfile
    : AutoMapper.Profile
{
    public GoKefuProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoKefu, Example.Entity.Domain.Models.GoKefuReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoKefuCreateModel, Example.Entity.Data.Entities.GoKefu>();

        CreateMap<Example.Entity.Data.Entities.GoKefu, Example.Entity.Domain.Models.GoKefuCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoKefu, Example.Entity.Domain.Models.GoKefuUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoKefuUpdateModel, Example.Entity.Data.Entities.GoKefu>();

        CreateMap<Example.Entity.Domain.Models.GoKefuReadModel, Example.Entity.Domain.Models.GoKefuUpdateModel>();

    }

}
