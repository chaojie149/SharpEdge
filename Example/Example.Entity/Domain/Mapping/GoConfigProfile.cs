using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoConfigProfile
    : AutoMapper.Profile
{
    public GoConfigProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoConfig, Example.Entity.Domain.Models.GoConfigReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoConfigCreateModel, Example.Entity.Data.Entities.GoConfig>();

        CreateMap<Example.Entity.Data.Entities.GoConfig, Example.Entity.Domain.Models.GoConfigCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoConfig, Example.Entity.Domain.Models.GoConfigUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoConfigUpdateModel, Example.Entity.Data.Entities.GoConfig>();

        CreateMap<Example.Entity.Domain.Models.GoConfigReadModel, Example.Entity.Domain.Models.GoConfigUpdateModel>();

    }

}
