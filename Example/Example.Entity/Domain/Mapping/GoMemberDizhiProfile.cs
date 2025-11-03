using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberDizhiProfile
    : AutoMapper.Profile
{
    public GoMemberDizhiProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberDizhi, Example.Entity.Domain.Models.GoMemberDizhiReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberDizhiCreateModel, Example.Entity.Data.Entities.GoMemberDizhi>();

        CreateMap<Example.Entity.Data.Entities.GoMemberDizhi, Example.Entity.Domain.Models.GoMemberDizhiCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberDizhi, Example.Entity.Domain.Models.GoMemberDizhiUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberDizhiUpdateModel, Example.Entity.Data.Entities.GoMemberDizhi>();

        CreateMap<Example.Entity.Domain.Models.GoMemberDizhiReadModel, Example.Entity.Domain.Models.GoMemberDizhiUpdateModel>();

    }

}
