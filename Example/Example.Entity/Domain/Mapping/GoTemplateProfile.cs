using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoTemplateProfile
    : AutoMapper.Profile
{
    public GoTemplateProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoTemplate, Example.Entity.Domain.Models.GoTemplateReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoTemplateCreateModel, Example.Entity.Data.Entities.GoTemplate>();

        CreateMap<Example.Entity.Data.Entities.GoTemplate, Example.Entity.Domain.Models.GoTemplateCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoTemplate, Example.Entity.Domain.Models.GoTemplateUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoTemplateUpdateModel, Example.Entity.Data.Entities.GoTemplate>();

        CreateMap<Example.Entity.Domain.Models.GoTemplateReadModel, Example.Entity.Domain.Models.GoTemplateUpdateModel>();

    }

}
