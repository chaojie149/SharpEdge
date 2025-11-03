using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoVoteActiverProfile
    : AutoMapper.Profile
{
    public GoVoteActiverProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoVoteActiver, Example.Entity.Domain.Models.GoVoteActiverReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoVoteActiverCreateModel, Example.Entity.Data.Entities.GoVoteActiver>();

        CreateMap<Example.Entity.Data.Entities.GoVoteActiver, Example.Entity.Domain.Models.GoVoteActiverCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoVoteActiver, Example.Entity.Domain.Models.GoVoteActiverUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoVoteActiverUpdateModel, Example.Entity.Data.Entities.GoVoteActiver>();

        CreateMap<Example.Entity.Domain.Models.GoVoteActiverReadModel, Example.Entity.Domain.Models.GoVoteActiverUpdateModel>();

    }

}
