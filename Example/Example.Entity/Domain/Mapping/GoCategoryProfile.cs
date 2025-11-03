using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCategoryProfile
    : AutoMapper.Profile
{
    public GoCategoryProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCategory, Example.Entity.Domain.Models.GoCategoryReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCategoryCreateModel, Example.Entity.Data.Entities.GoCategory>();

        CreateMap<Example.Entity.Data.Entities.GoCategory, Example.Entity.Domain.Models.GoCategoryCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCategory, Example.Entity.Domain.Models.GoCategoryUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCategoryUpdateModel, Example.Entity.Data.Entities.GoCategory>();

        CreateMap<Example.Entity.Domain.Models.GoCategoryReadModel, Example.Entity.Domain.Models.GoCategoryUpdateModel>();

    }

}
