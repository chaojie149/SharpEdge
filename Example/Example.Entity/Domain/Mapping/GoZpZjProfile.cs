using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoZpZjProfile
    : AutoMapper.Profile
{
    public GoZpZjProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoZpZj, Example.Entity.Domain.Models.GoZpZjReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoZpZjCreateModel, Example.Entity.Data.Entities.GoZpZj>();

        CreateMap<Example.Entity.Data.Entities.GoZpZj, Example.Entity.Domain.Models.GoZpZjCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoZpZj, Example.Entity.Domain.Models.GoZpZjUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoZpZjUpdateModel, Example.Entity.Data.Entities.GoZpZj>();

        CreateMap<Example.Entity.Domain.Models.GoZpZjReadModel, Example.Entity.Domain.Models.GoZpZjUpdateModel>();

    }

}
