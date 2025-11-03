using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoQqsetProfile
    : AutoMapper.Profile
{
    public GoQqsetProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoQqset, Example.Entity.Domain.Models.GoQqsetReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoQqsetCreateModel, Example.Entity.Data.Entities.GoQqset>();

        CreateMap<Example.Entity.Data.Entities.GoQqset, Example.Entity.Domain.Models.GoQqsetCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoQqset, Example.Entity.Domain.Models.GoQqsetUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoQqsetUpdateModel, Example.Entity.Data.Entities.GoQqset>();

        CreateMap<Example.Entity.Domain.Models.GoQqsetReadModel, Example.Entity.Domain.Models.GoQqsetUpdateModel>();

    }

}
