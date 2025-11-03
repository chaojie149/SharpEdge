using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShoplistProfile
    : AutoMapper.Profile
{
    public GoShoplistProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShoplist, Example.Entity.Domain.Models.GoShoplistReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistCreateModel, Example.Entity.Data.Entities.GoShoplist>();

        CreateMap<Example.Entity.Data.Entities.GoShoplist, Example.Entity.Domain.Models.GoShoplistCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShoplist, Example.Entity.Domain.Models.GoShoplistUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistUpdateModel, Example.Entity.Data.Entities.GoShoplist>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistReadModel, Example.Entity.Domain.Models.GoShoplistUpdateModel>();

    }

}
