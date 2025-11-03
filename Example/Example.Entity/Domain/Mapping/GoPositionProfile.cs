using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoPositionProfile
    : AutoMapper.Profile
{
    public GoPositionProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoPosition, Example.Entity.Domain.Models.GoPositionReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoPositionCreateModel, Example.Entity.Data.Entities.GoPosition>();

        CreateMap<Example.Entity.Data.Entities.GoPosition, Example.Entity.Domain.Models.GoPositionCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoPosition, Example.Entity.Domain.Models.GoPositionUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoPositionUpdateModel, Example.Entity.Data.Entities.GoPosition>();

        CreateMap<Example.Entity.Domain.Models.GoPositionReadModel, Example.Entity.Domain.Models.GoPositionUpdateModel>();

    }

}
