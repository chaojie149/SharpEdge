using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoGoogleProfile
    : AutoMapper.Profile
{
    public GoGoogleProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoGoogle, Example.Entity.Domain.Models.GoGoogleReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoGoogleCreateModel, Example.Entity.Data.Entities.GoGoogle>();

        CreateMap<Example.Entity.Data.Entities.GoGoogle, Example.Entity.Domain.Models.GoGoogleCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoGoogle, Example.Entity.Domain.Models.GoGoogleUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoGoogleUpdateModel, Example.Entity.Data.Entities.GoGoogle>();

        CreateMap<Example.Entity.Domain.Models.GoGoogleReadModel, Example.Entity.Domain.Models.GoGoogleUpdateModel>();

    }

}
