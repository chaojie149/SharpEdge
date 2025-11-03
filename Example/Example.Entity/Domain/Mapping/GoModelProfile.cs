using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoModelProfile
    : AutoMapper.Profile
{
    public GoModelProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoModel, Example.Entity.Domain.Models.GoModelReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoModelCreateModel, Example.Entity.Data.Entities.GoModel>();

        CreateMap<Example.Entity.Data.Entities.GoModel, Example.Entity.Domain.Models.GoModelCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoModel, Example.Entity.Domain.Models.GoModelUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoModelUpdateModel, Example.Entity.Data.Entities.GoModel>();

        CreateMap<Example.Entity.Domain.Models.GoModelReadModel, Example.Entity.Domain.Models.GoModelUpdateModel>();

    }

}
