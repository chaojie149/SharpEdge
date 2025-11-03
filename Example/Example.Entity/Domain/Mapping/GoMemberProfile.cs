using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberProfile
    : AutoMapper.Profile
{
    public GoMemberProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMember, Example.Entity.Domain.Models.GoMemberReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCreateModel, Example.Entity.Data.Entities.GoMember>();

        CreateMap<Example.Entity.Data.Entities.GoMember, Example.Entity.Domain.Models.GoMemberCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMember, Example.Entity.Domain.Models.GoMemberUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberUpdateModel, Example.Entity.Data.Entities.GoMember>();

        CreateMap<Example.Entity.Domain.Models.GoMemberReadModel, Example.Entity.Domain.Models.GoMemberUpdateModel>();

    }

}
