using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWechatConfigProfile
    : AutoMapper.Profile
{
    public GoWechatConfigProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWechatConfig, Example.Entity.Domain.Models.GoWechatConfigReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWechatConfigCreateModel, Example.Entity.Data.Entities.GoWechatConfig>();

        CreateMap<Example.Entity.Data.Entities.GoWechatConfig, Example.Entity.Domain.Models.GoWechatConfigCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWechatConfig, Example.Entity.Domain.Models.GoWechatConfigUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWechatConfigUpdateModel, Example.Entity.Data.Entities.GoWechatConfig>();

        CreateMap<Example.Entity.Domain.Models.GoWechatConfigReadModel, Example.Entity.Domain.Models.GoWechatConfigUpdateModel>();

    }

}
