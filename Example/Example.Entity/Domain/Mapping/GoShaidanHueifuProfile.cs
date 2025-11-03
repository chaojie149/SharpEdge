using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShaidanHueifuProfile
    : AutoMapper.Profile
{
    public GoShaidanHueifuProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShaidanHueifu, Example.Entity.Domain.Models.GoShaidanHueifuReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShaidanHueifuCreateModel, Example.Entity.Data.Entities.GoShaidanHueifu>();

        CreateMap<Example.Entity.Data.Entities.GoShaidanHueifu, Example.Entity.Domain.Models.GoShaidanHueifuCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShaidanHueifu, Example.Entity.Domain.Models.GoShaidanHueifuUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShaidanHueifuUpdateModel, Example.Entity.Data.Entities.GoShaidanHueifu>();

        CreateMap<Example.Entity.Domain.Models.GoShaidanHueifuReadModel, Example.Entity.Domain.Models.GoShaidanHueifuUpdateModel>();

    }

}
