using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCurrencyProfile
    : AutoMapper.Profile
{
    public GoCurrencyProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCurrency, Example.Entity.Domain.Models.GoCurrencyReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCurrencyCreateModel, Example.Entity.Data.Entities.GoCurrency>();

        CreateMap<Example.Entity.Data.Entities.GoCurrency, Example.Entity.Domain.Models.GoCurrencyCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCurrency, Example.Entity.Domain.Models.GoCurrencyUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCurrencyUpdateModel, Example.Entity.Data.Entities.GoCurrency>();

        CreateMap<Example.Entity.Domain.Models.GoCurrencyReadModel, Example.Entity.Domain.Models.GoCurrencyUpdateModel>();

    }

}
