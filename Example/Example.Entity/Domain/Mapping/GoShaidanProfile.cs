using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShaidanProfile
    : AutoMapper.Profile
{
    public GoShaidanProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShaidan, Example.Entity.Domain.Models.GoShaidanReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShaidanCreateModel, Example.Entity.Data.Entities.GoShaidan>();

        CreateMap<Example.Entity.Data.Entities.GoShaidan, Example.Entity.Domain.Models.GoShaidanCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShaidan, Example.Entity.Domain.Models.GoShaidanUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShaidanUpdateModel, Example.Entity.Data.Entities.GoShaidan>();

        CreateMap<Example.Entity.Domain.Models.GoShaidanReadModel, Example.Entity.Domain.Models.GoShaidanUpdateModel>();

    }

}
