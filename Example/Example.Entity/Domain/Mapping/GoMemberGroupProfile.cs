using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberGroupProfile
    : AutoMapper.Profile
{
    public GoMemberGroupProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberGroup, Example.Entity.Domain.Models.GoMemberGroupReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberGroupCreateModel, Example.Entity.Data.Entities.GoMemberGroup>();

        CreateMap<Example.Entity.Data.Entities.GoMemberGroup, Example.Entity.Domain.Models.GoMemberGroupCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberGroup, Example.Entity.Domain.Models.GoMemberGroupUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberGroupUpdateModel, Example.Entity.Data.Entities.GoMemberGroup>();

        CreateMap<Example.Entity.Domain.Models.GoMemberGroupReadModel, Example.Entity.Domain.Models.GoMemberGroupUpdateModel>();

    }

}
