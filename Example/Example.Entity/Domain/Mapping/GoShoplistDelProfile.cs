using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShoplistDelProfile
    : AutoMapper.Profile
{
    public GoShoplistDelProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShoplistDel, Example.Entity.Domain.Models.GoShoplistDelReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistDelCreateModel, Example.Entity.Data.Entities.GoShoplistDel>();

        CreateMap<Example.Entity.Data.Entities.GoShoplistDel, Example.Entity.Domain.Models.GoShoplistDelCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShoplistDel, Example.Entity.Domain.Models.GoShoplistDelUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistDelUpdateModel, Example.Entity.Data.Entities.GoShoplistDel>();

        CreateMap<Example.Entity.Domain.Models.GoShoplistDelReadModel, Example.Entity.Domain.Models.GoShoplistDelUpdateModel>();

    }

}
