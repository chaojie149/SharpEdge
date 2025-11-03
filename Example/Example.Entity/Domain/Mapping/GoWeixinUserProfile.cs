using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinUserProfile
    : AutoMapper.Profile
{
    public GoWeixinUserProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinUser, Example.Entity.Domain.Models.GoWeixinUserReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinUserCreateModel, Example.Entity.Data.Entities.GoWeixinUser>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinUser, Example.Entity.Domain.Models.GoWeixinUserCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinUser, Example.Entity.Domain.Models.GoWeixinUserUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinUserUpdateModel, Example.Entity.Data.Entities.GoWeixinUser>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinUserReadModel, Example.Entity.Domain.Models.GoWeixinUserUpdateModel>();

    }

}
