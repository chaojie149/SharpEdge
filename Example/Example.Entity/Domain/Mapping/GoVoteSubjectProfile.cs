using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoVoteSubjectProfile
    : AutoMapper.Profile
{
    public GoVoteSubjectProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoVoteSubject, Example.Entity.Domain.Models.GoVoteSubjectReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoVoteSubjectCreateModel, Example.Entity.Data.Entities.GoVoteSubject>();

        CreateMap<Example.Entity.Data.Entities.GoVoteSubject, Example.Entity.Domain.Models.GoVoteSubjectCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoVoteSubject, Example.Entity.Domain.Models.GoVoteSubjectUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoVoteSubjectUpdateModel, Example.Entity.Data.Entities.GoVoteSubject>();

        CreateMap<Example.Entity.Domain.Models.GoVoteSubjectReadModel, Example.Entity.Domain.Models.GoVoteSubjectUpdateModel>();

    }

}
