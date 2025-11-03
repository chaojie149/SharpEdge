using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoQiandaoProfile
    : AutoMapper.Profile
{
    public GoQiandaoProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoQiandao, Example.Entity.Domain.Models.GoQiandaoReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoQiandaoCreateModel, Example.Entity.Data.Entities.GoQiandao>();

        CreateMap<Example.Entity.Data.Entities.GoQiandao, Example.Entity.Domain.Models.GoQiandaoCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoQiandao, Example.Entity.Domain.Models.GoQiandaoUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoQiandaoUpdateModel, Example.Entity.Data.Entities.GoQiandao>();

        CreateMap<Example.Entity.Domain.Models.GoQiandaoReadModel, Example.Entity.Domain.Models.GoQiandaoUpdateModel>();

    }

}
