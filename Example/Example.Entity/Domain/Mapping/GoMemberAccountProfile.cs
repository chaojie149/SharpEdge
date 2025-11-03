using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberAccountProfile
    : AutoMapper.Profile
{
    public GoMemberAccountProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberAccount, Example.Entity.Domain.Models.GoMemberAccountReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberAccountCreateModel, Example.Entity.Data.Entities.GoMemberAccount>();

        CreateMap<Example.Entity.Data.Entities.GoMemberAccount, Example.Entity.Domain.Models.GoMemberAccountCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberAccount, Example.Entity.Domain.Models.GoMemberAccountUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberAccountUpdateModel, Example.Entity.Data.Entities.GoMemberAccount>();

        CreateMap<Example.Entity.Domain.Models.GoMemberAccountReadModel, Example.Entity.Domain.Models.GoMemberAccountUpdateModel>();

    }

}
