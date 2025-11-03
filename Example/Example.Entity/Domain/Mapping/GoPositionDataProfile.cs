using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoPositionDataProfile
    : AutoMapper.Profile
{
    public GoPositionDataProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoPositionData, Example.Entity.Domain.Models.GoPositionDataReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoPositionDataCreateModel, Example.Entity.Data.Entities.GoPositionData>();

        CreateMap<Example.Entity.Data.Entities.GoPositionData, Example.Entity.Domain.Models.GoPositionDataCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoPositionData, Example.Entity.Domain.Models.GoPositionDataUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoPositionDataUpdateModel, Example.Entity.Data.Entities.GoPositionData>();

        CreateMap<Example.Entity.Domain.Models.GoPositionDataReadModel, Example.Entity.Domain.Models.GoPositionDataUpdateModel>();

    }

}
