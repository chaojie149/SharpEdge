using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShopcollectProfile
    : AutoMapper.Profile
{
    public GoShopcollectProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShopcollect, Example.Entity.Domain.Models.GoShopcollectReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShopcollectCreateModel, Example.Entity.Data.Entities.GoShopcollect>();

        CreateMap<Example.Entity.Data.Entities.GoShopcollect, Example.Entity.Domain.Models.GoShopcollectCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShopcollect, Example.Entity.Domain.Models.GoShopcollectUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShopcollectUpdateModel, Example.Entity.Data.Entities.GoShopcollect>();

        CreateMap<Example.Entity.Domain.Models.GoShopcollectReadModel, Example.Entity.Domain.Models.GoShopcollectUpdateModel>();

    }

}
