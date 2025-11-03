using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoAdDataProfile
    : AutoMapper.Profile
{
    public GoAdDataProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoAdData, Example.Entity.Domain.Models.GoAdDataReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdDataCreateModel, Example.Entity.Data.Entities.GoAdData>();

        CreateMap<Example.Entity.Data.Entities.GoAdData, Example.Entity.Domain.Models.GoAdDataCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoAdData, Example.Entity.Domain.Models.GoAdDataUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdDataUpdateModel, Example.Entity.Data.Entities.GoAdData>();

        CreateMap<Example.Entity.Domain.Models.GoAdDataReadModel, Example.Entity.Domain.Models.GoAdDataUpdateModel>();

    }

}
