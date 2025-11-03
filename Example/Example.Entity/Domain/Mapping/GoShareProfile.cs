using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShareProfile
    : AutoMapper.Profile
{
    public GoShareProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShare, Example.Entity.Domain.Models.GoShareReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShareCreateModel, Example.Entity.Data.Entities.GoShare>();

        CreateMap<Example.Entity.Data.Entities.GoShare, Example.Entity.Domain.Models.GoShareCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShare, Example.Entity.Domain.Models.GoShareUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShareUpdateModel, Example.Entity.Data.Entities.GoShare>();

        CreateMap<Example.Entity.Domain.Models.GoShareReadModel, Example.Entity.Domain.Models.GoShareUpdateModel>();

    }

}
