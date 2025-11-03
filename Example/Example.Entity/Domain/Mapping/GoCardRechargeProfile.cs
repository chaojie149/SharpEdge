using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCardRechargeProfile
    : AutoMapper.Profile
{
    public GoCardRechargeProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCardRecharge, Example.Entity.Domain.Models.GoCardRechargeReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCardRechargeCreateModel, Example.Entity.Data.Entities.GoCardRecharge>();

        CreateMap<Example.Entity.Data.Entities.GoCardRecharge, Example.Entity.Domain.Models.GoCardRechargeCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCardRecharge, Example.Entity.Domain.Models.GoCardRechargeUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCardRechargeUpdateModel, Example.Entity.Data.Entities.GoCardRecharge>();

        CreateMap<Example.Entity.Domain.Models.GoCardRechargeReadModel, Example.Entity.Domain.Models.GoCardRechargeUpdateModel>();

    }

}
