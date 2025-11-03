using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinBonusProfile
    : AutoMapper.Profile
{
    public GoWeixinBonusProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinBonus, Example.Entity.Domain.Models.GoWeixinBonusReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinBonusCreateModel, Example.Entity.Data.Entities.GoWeixinBonus>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinBonus, Example.Entity.Domain.Models.GoWeixinBonusCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinBonus, Example.Entity.Domain.Models.GoWeixinBonusUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinBonusUpdateModel, Example.Entity.Data.Entities.GoWeixinBonus>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinBonusReadModel, Example.Entity.Domain.Models.GoWeixinBonusUpdateModel>();

    }

}
