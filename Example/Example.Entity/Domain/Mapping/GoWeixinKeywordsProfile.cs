using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinKeywordsProfile
    : AutoMapper.Profile
{
    public GoWeixinKeywordsProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinKeywords, Example.Entity.Domain.Models.GoWeixinKeywordsReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinKeywordsCreateModel, Example.Entity.Data.Entities.GoWeixinKeywords>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinKeywords, Example.Entity.Domain.Models.GoWeixinKeywordsCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinKeywords, Example.Entity.Domain.Models.GoWeixinKeywordsUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinKeywordsUpdateModel, Example.Entity.Data.Entities.GoWeixinKeywords>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinKeywordsReadModel, Example.Entity.Domain.Models.GoWeixinKeywordsUpdateModel>();

    }

}
