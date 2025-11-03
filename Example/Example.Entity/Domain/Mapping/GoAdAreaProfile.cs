using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoAdAreaProfile
    : AutoMapper.Profile
{
    public GoAdAreaProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoAdArea, Example.Entity.Domain.Models.GoAdAreaReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdAreaCreateModel, Example.Entity.Data.Entities.GoAdArea>();

        CreateMap<Example.Entity.Data.Entities.GoAdArea, Example.Entity.Domain.Models.GoAdAreaCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoAdArea, Example.Entity.Domain.Models.GoAdAreaUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdAreaUpdateModel, Example.Entity.Data.Entities.GoAdArea>();

        CreateMap<Example.Entity.Domain.Models.GoAdAreaReadModel, Example.Entity.Domain.Models.GoAdAreaUpdateModel>();

    }

}
