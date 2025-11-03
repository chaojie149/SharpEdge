using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinPointProfile
    : AutoMapper.Profile
{
    public GoWeixinPointProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinPoint, Example.Entity.Domain.Models.GoWeixinPointReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinPointCreateModel, Example.Entity.Data.Entities.GoWeixinPoint>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinPoint, Example.Entity.Domain.Models.GoWeixinPointCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinPoint, Example.Entity.Domain.Models.GoWeixinPointUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinPointUpdateModel, Example.Entity.Data.Entities.GoWeixinPoint>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinPointReadModel, Example.Entity.Domain.Models.GoWeixinPointUpdateModel>();

    }

}
