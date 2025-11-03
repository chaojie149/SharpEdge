using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShoplistCopyProfile
    : AutoMapper.Profile
{
    public GoShoplistCopyProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShoplistCopy, Example.Entity.Domain.Models.GoShoplistCopyReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistCopyCreateModel, Example.Entity.Data.Entities.GoShoplistCopy>();

        CreateMap<Example.Entity.Data.Entities.GoShoplistCopy, Example.Entity.Domain.Models.GoShoplistCopyCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShoplistCopy, Example.Entity.Domain.Models.GoShoplistCopyUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistCopyUpdateModel, Example.Entity.Data.Entities.GoShoplistCopy>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistCopyReadModel, Example.Entity.Domain.Models.GoShoplistCopyUpdateModel>();

    }

}
