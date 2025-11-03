using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMentsProfile
    : AutoMapper.Profile
{
    public GoMentsProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMents, Example.Entity.Domain.Models.GoMentsReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMentsCreateModel, Example.Entity.Data.Entities.GoMents>();

        CreateMap<Example.Entity.Data.Entities.GoMents, Example.Entity.Domain.Models.GoMentsCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMents, Example.Entity.Domain.Models.GoMentsUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMentsUpdateModel, Example.Entity.Data.Entities.GoMents>();

        CreateMap<Example.Entity.Domain.Models.GoMentsReadModel, Example.Entity.Domain.Models.GoMentsUpdateModel>();

    }

}
