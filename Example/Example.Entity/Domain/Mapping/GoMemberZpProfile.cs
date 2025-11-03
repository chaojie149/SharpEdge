using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberZpProfile
    : AutoMapper.Profile
{
    public GoMemberZpProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberZp, Example.Entity.Domain.Models.GoMemberZpReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberZpCreateModel, Example.Entity.Data.Entities.GoMemberZp>();

        CreateMap<Example.Entity.Data.Entities.GoMemberZp, Example.Entity.Domain.Models.GoMemberZpCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberZp, Example.Entity.Domain.Models.GoMemberZpUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberZpUpdateModel, Example.Entity.Data.Entities.GoMemberZp>();

        CreateMap<Example.Entity.Domain.Models.GoMemberZpReadModel, Example.Entity.Domain.Models.GoMemberZpUpdateModel>();

    }

}
