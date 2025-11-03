using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinSignProfile
    : AutoMapper.Profile
{
    public GoWeixinSignProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinSign, Example.Entity.Domain.Models.GoWeixinSignReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinSignCreateModel, Example.Entity.Data.Entities.GoWeixinSign>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinSign, Example.Entity.Domain.Models.GoWeixinSignCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinSign, Example.Entity.Domain.Models.GoWeixinSignUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinSignUpdateModel, Example.Entity.Data.Entities.GoWeixinSign>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinSignReadModel, Example.Entity.Domain.Models.GoWeixinSignUpdateModel>();

    }

}
