using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoBrandProfile
    : AutoMapper.Profile
{
    public GoBrandProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoBrand, Example.Entity.Domain.Models.GoBrandReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoBrandCreateModel, Example.Entity.Data.Entities.GoBrand>();

        CreateMap<Example.Entity.Data.Entities.GoBrand, Example.Entity.Domain.Models.GoBrandCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoBrand, Example.Entity.Domain.Models.GoBrandUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoBrandUpdateModel, Example.Entity.Data.Entities.GoBrand>();

        CreateMap<Example.Entity.Domain.Models.GoBrandReadModel, Example.Entity.Domain.Models.GoBrandUpdateModel>();

    }

}
