using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWxchCfgProfile
    : AutoMapper.Profile
{
    public GoWxchCfgProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWxchCfg, Example.Entity.Domain.Models.GoWxchCfgReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWxchCfgCreateModel, Example.Entity.Data.Entities.GoWxchCfg>();

        CreateMap<Example.Entity.Data.Entities.GoWxchCfg, Example.Entity.Domain.Models.GoWxchCfgCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWxchCfg, Example.Entity.Domain.Models.GoWxchCfgUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWxchCfgUpdateModel, Example.Entity.Data.Entities.GoWxchCfg>();

        CreateMap<Example.Entity.Domain.Models.GoWxchCfgReadModel, Example.Entity.Domain.Models.GoWxchCfgUpdateModel>();

    }

}
