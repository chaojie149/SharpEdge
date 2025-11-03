using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCachesProfile
    : AutoMapper.Profile
{
    public GoCachesProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCaches, Example.Entity.Domain.Models.GoCachesReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCachesCreateModel, Example.Entity.Data.Entities.GoCaches>();

        CreateMap<Example.Entity.Data.Entities.GoCaches, Example.Entity.Domain.Models.GoCachesCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCaches, Example.Entity.Domain.Models.GoCachesUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCachesUpdateModel, Example.Entity.Data.Entities.GoCaches>();

        CreateMap<Example.Entity.Domain.Models.GoCachesReadModel, Example.Entity.Domain.Models.GoCachesUpdateModel>();

    }

}
