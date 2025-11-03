using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoZpNumberProfile
    : AutoMapper.Profile
{
    public GoZpNumberProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoZpNumber, Example.Entity.Domain.Models.GoZpNumberReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoZpNumberCreateModel, Example.Entity.Data.Entities.GoZpNumber>();

        CreateMap<Example.Entity.Data.Entities.GoZpNumber, Example.Entity.Domain.Models.GoZpNumberCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoZpNumber, Example.Entity.Domain.Models.GoZpNumberUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoZpNumberUpdateModel, Example.Entity.Data.Entities.GoZpNumber>();

        CreateMap<Example.Entity.Domain.Models.GoZpNumberReadModel, Example.Entity.Domain.Models.GoZpNumberUpdateModel>();

    }

}
