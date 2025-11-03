using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoNavigationProfile
    : AutoMapper.Profile
{
    public GoNavigationProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoNavigation, Example.Entity.Domain.Models.GoNavigationReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoNavigationCreateModel, Example.Entity.Data.Entities.GoNavigation>();

        CreateMap<Example.Entity.Data.Entities.GoNavigation, Example.Entity.Domain.Models.GoNavigationCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoNavigation, Example.Entity.Domain.Models.GoNavigationUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoNavigationUpdateModel, Example.Entity.Data.Entities.GoNavigation>();

        CreateMap<Example.Entity.Domain.Models.GoNavigationReadModel, Example.Entity.Domain.Models.GoNavigationUpdateModel>();

    }

}
