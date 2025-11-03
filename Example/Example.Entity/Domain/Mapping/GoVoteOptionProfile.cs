using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoVoteOptionProfile
    : AutoMapper.Profile
{
    public GoVoteOptionProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoVoteOption, Example.Entity.Domain.Models.GoVoteOptionReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoVoteOptionCreateModel, Example.Entity.Data.Entities.GoVoteOption>();

        CreateMap<Example.Entity.Data.Entities.GoVoteOption, Example.Entity.Domain.Models.GoVoteOptionCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoVoteOption, Example.Entity.Domain.Models.GoVoteOptionUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoVoteOptionUpdateModel, Example.Entity.Data.Entities.GoVoteOption>();

        CreateMap<Example.Entity.Domain.Models.GoVoteOptionReadModel, Example.Entity.Domain.Models.GoVoteOptionUpdateModel>();

    }

}
