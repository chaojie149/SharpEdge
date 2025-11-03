using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoLanguageProfile
    : AutoMapper.Profile
{
    public GoLanguageProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoLanguage, Example.Entity.Domain.Models.GoLanguageReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoLanguageCreateModel, Example.Entity.Data.Entities.GoLanguage>();

        CreateMap<Example.Entity.Data.Entities.GoLanguage, Example.Entity.Domain.Models.GoLanguageCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoLanguage, Example.Entity.Domain.Models.GoLanguageUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoLanguageUpdateModel, Example.Entity.Data.Entities.GoLanguage>();

        CreateMap<Example.Entity.Domain.Models.GoLanguageReadModel, Example.Entity.Domain.Models.GoLanguageUpdateModel>();

    }

}
