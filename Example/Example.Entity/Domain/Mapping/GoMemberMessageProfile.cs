using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberMessageProfile
    : AutoMapper.Profile
{
    public GoMemberMessageProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberMessage, Example.Entity.Domain.Models.GoMemberMessageReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberMessageCreateModel, Example.Entity.Data.Entities.GoMemberMessage>();

        CreateMap<Example.Entity.Data.Entities.GoMemberMessage, Example.Entity.Domain.Models.GoMemberMessageCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberMessage, Example.Entity.Domain.Models.GoMemberMessageUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberMessageUpdateModel, Example.Entity.Data.Entities.GoMemberMessage>();

        CreateMap<Example.Entity.Domain.Models.GoMemberMessageReadModel, Example.Entity.Domain.Models.GoMemberMessageUpdateModel>();

    }

}
