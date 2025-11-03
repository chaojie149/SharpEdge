using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoQuanziTieziProfile
    : AutoMapper.Profile
{
    public GoQuanziTieziProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoQuanziTiezi, Example.Entity.Domain.Models.GoQuanziTieziReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziTieziCreateModel, Example.Entity.Data.Entities.GoQuanziTiezi>();

        CreateMap<Example.Entity.Data.Entities.GoQuanziTiezi, Example.Entity.Domain.Models.GoQuanziTieziCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoQuanziTiezi, Example.Entity.Domain.Models.GoQuanziTieziUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziTieziUpdateModel, Example.Entity.Data.Entities.GoQuanziTiezi>();

        CreateMap<Example.Entity.Domain.Models.GoQuanziTieziReadModel, Example.Entity.Domain.Models.GoQuanziTieziUpdateModel>();

    }

}
