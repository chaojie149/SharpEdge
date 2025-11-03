using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinBonusTypeProfile
    : AutoMapper.Profile
{
    public GoWeixinBonusTypeProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinBonusType, Example.Entity.Domain.Models.GoWeixinBonusTypeReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinBonusTypeCreateModel, Example.Entity.Data.Entities.GoWeixinBonusType>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinBonusType, Example.Entity.Domain.Models.GoWeixinBonusTypeCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinBonusType, Example.Entity.Domain.Models.GoWeixinBonusTypeUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinBonusTypeUpdateModel, Example.Entity.Data.Entities.GoWeixinBonusType>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinBonusTypeReadModel, Example.Entity.Domain.Models.GoWeixinBonusTypeUpdateModel>();

    }

}
