using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoLogisticsProfile
    : AutoMapper.Profile
{
    public GoLogisticsProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoLogistics, Example.Entity.Domain.Models.GoLogisticsReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoLogisticsCreateModel, Example.Entity.Data.Entities.GoLogistics>();

        CreateMap<Example.Entity.Data.Entities.GoLogistics, Example.Entity.Domain.Models.GoLogisticsCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoLogistics, Example.Entity.Domain.Models.GoLogisticsUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoLogisticsUpdateModel, Example.Entity.Data.Entities.GoLogistics>();

        CreateMap<Example.Entity.Domain.Models.GoLogisticsReadModel, Example.Entity.Domain.Models.GoLogisticsUpdateModel>();

    }

}
