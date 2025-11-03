using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWapProfile
    : AutoMapper.Profile
{
    public GoWapProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWap, Example.Entity.Domain.Models.GoWapReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWapCreateModel, Example.Entity.Data.Entities.GoWap>();

        CreateMap<Example.Entity.Data.Entities.GoWap, Example.Entity.Domain.Models.GoWapCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWap, Example.Entity.Domain.Models.GoWapUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWapUpdateModel, Example.Entity.Data.Entities.GoWap>();

        CreateMap<Example.Entity.Domain.Models.GoWapReadModel, Example.Entity.Domain.Models.GoWapUpdateModel>();

    }

}
