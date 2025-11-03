using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoRegMoneyProfile
    : AutoMapper.Profile
{
    public GoRegMoneyProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoRegMoney, Example.Entity.Domain.Models.GoRegMoneyReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoRegMoneyCreateModel, Example.Entity.Data.Entities.GoRegMoney>();

        CreateMap<Example.Entity.Data.Entities.GoRegMoney, Example.Entity.Domain.Models.GoRegMoneyCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoRegMoney, Example.Entity.Domain.Models.GoRegMoneyUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoRegMoneyUpdateModel, Example.Entity.Data.Entities.GoRegMoney>();

        CreateMap<Example.Entity.Domain.Models.GoRegMoneyReadModel, Example.Entity.Domain.Models.GoRegMoneyUpdateModel>();

    }

}
