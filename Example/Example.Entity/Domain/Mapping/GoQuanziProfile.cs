using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoQuanziProfile
    : AutoMapper.Profile
{
    public GoQuanziProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoQuanzi, Example.Entity.Domain.Models.GoQuanziReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziCreateModel, Example.Entity.Data.Entities.GoQuanzi>();

        CreateMap<Example.Entity.Data.Entities.GoQuanzi, Example.Entity.Domain.Models.GoQuanziCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoQuanzi, Example.Entity.Domain.Models.GoQuanziUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziUpdateModel, Example.Entity.Data.Entities.GoQuanzi>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziReadModel, Example.Entity.Domain.Models.GoQuanziUpdateModel>();

    }

}
