using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoFundProfile
    : AutoMapper.Profile
{
    public GoFundProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoFund, Example.Entity.Domain.Models.GoFundReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoFundCreateModel, Example.Entity.Data.Entities.GoFund>();

        CreateMap<Example.Entity.Data.Entities.GoFund, Example.Entity.Domain.Models.GoFundCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoFund, Example.Entity.Domain.Models.GoFundUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoFundUpdateModel, Example.Entity.Data.Entities.GoFund>();

        CreateMap<Example.Entity.Domain.Models.GoFundReadModel, Example.Entity.Domain.Models.GoFundUpdateModel>();

    }

}
