using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class SignInProfile
    : AutoMapper.Profile
{
    public SignInProfile()
    {
        CreateMap<Example.Entity.Data.Entities.SignIn, Example.Entity.Domain.Models.SignInReadModel>();

        CreateMap<Example.Entity.Domain.Models.SignInCreateModel, Example.Entity.Data.Entities.SignIn>();

        CreateMap<Example.Entity.Data.Entities.SignIn, Example.Entity.Domain.Models.SignInCreateModel>();

        CreateMap<Example.Entity.Data.Entities.SignIn, Example.Entity.Domain.Models.SignInUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.SignInUpdateModel, Example.Entity.Data.Entities.SignIn>();

        CreateMap<Example.Entity.Domain.Models.SignInReadModel, Example.Entity.Domain.Models.SignInUpdateModel>();

    }

}
