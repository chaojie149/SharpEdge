using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoDisProfile
    : AutoMapper.Profile
{
    public GoDisProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoDis, Example.Entity.Domain.Models.GoDisReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoDisCreateModel, Example.Entity.Data.Entities.GoDis>();

        CreateMap<Example.Entity.Data.Entities.GoDis, Example.Entity.Domain.Models.GoDisCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoDis, Example.Entity.Domain.Models.GoDisUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoDisUpdateModel, Example.Entity.Data.Entities.GoDis>();

        CreateMap<Example.Entity.Domain.Models.GoDisReadModel, Example.Entity.Domain.Models.GoDisUpdateModel>();

    }

}
