using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoSignInProfile
    : AutoMapper.Profile
{
    public GoSignInProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoSignIn, Example.Entity.Domain.Models.GoSignInReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoSignInCreateModel, Example.Entity.Data.Entities.GoSignIn>();

        CreateMap<Example.Entity.Data.Entities.GoSignIn, Example.Entity.Domain.Models.GoSignInCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoSignIn, Example.Entity.Domain.Models.GoSignInUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoSignInUpdateModel, Example.Entity.Data.Entities.GoSignIn>();

        CreateMap<Example.Entity.Domain.Models.GoSignInReadModel, Example.Entity.Domain.Models.GoSignInUpdateModel>();

    }

}
