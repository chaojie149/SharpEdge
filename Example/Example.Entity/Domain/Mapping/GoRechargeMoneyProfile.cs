using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoRechargeMoneyProfile
    : AutoMapper.Profile
{
    public GoRechargeMoneyProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoRechargeMoney, Example.Entity.Domain.Models.GoRechargeMoneyReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoRechargeMoneyCreateModel, Example.Entity.Data.Entities.GoRechargeMoney>();

        CreateMap<Example.Entity.Data.Entities.GoRechargeMoney, Example.Entity.Domain.Models.GoRechargeMoneyCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoRechargeMoney, Example.Entity.Domain.Models.GoRechargeMoneyUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoRechargeMoneyUpdateModel, Example.Entity.Data.Entities.GoRechargeMoney>();

        CreateMap<Example.Entity.Domain.Models.GoRechargeMoneyReadModel, Example.Entity.Domain.Models.GoRechargeMoneyUpdateModel>();

    }

}
