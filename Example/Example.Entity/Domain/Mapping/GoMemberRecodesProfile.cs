using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberRecodesProfile
    : AutoMapper.Profile
{
    public GoMemberRecodesProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberRecodes, Example.Entity.Domain.Models.GoMemberRecodesReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRecodesCreateModel, Example.Entity.Data.Entities.GoMemberRecodes>();

        CreateMap<Example.Entity.Data.Entities.GoMemberRecodes, Example.Entity.Domain.Models.GoMemberRecodesCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberRecodes, Example.Entity.Domain.Models.GoMemberRecodesUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRecodesUpdateModel, Example.Entity.Data.Entities.GoMemberRecodes>();

        CreateMap<Example.Entity.Domain.Models.GoMemberRecodesReadModel, Example.Entity.Domain.Models.GoMemberRecodesUpdateModel>();

    }

}
