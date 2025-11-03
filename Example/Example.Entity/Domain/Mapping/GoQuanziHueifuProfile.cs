using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoQuanziHueifuProfile
    : AutoMapper.Profile
{
    public GoQuanziHueifuProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoQuanziHueifu, Example.Entity.Domain.Models.GoQuanziHueifuReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziHueifuCreateModel, Example.Entity.Data.Entities.GoQuanziHueifu>();

        CreateMap<Example.Entity.Data.Entities.GoQuanziHueifu, Example.Entity.Domain.Models.GoQuanziHueifuCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoQuanziHueifu, Example.Entity.Domain.Models.GoQuanziHueifuUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziHueifuUpdateModel, Example.Entity.Data.Entities.GoQuanziHueifu>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziHueifuReadModel, Example.Entity.Domain.Models.GoQuanziHueifuUpdateModel>();

    }

}
