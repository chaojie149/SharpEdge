using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCjcodeProfile
    : AutoMapper.Profile
{
    public GoCjcodeProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCjcode, Example.Entity.Domain.Models.GoCjcodeReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCjcodeCreateModel, Example.Entity.Data.Entities.GoCjcode>();

        CreateMap<Example.Entity.Data.Entities.GoCjcode, Example.Entity.Domain.Models.GoCjcodeCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCjcode, Example.Entity.Domain.Models.GoCjcodeUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCjcodeUpdateModel, Example.Entity.Data.Entities.GoCjcode>();

        CreateMap<Example.Entity.Domain.Models.GoCjcodeReadModel, Example.Entity.Domain.Models.GoCjcodeUpdateModel>();

    }

}
