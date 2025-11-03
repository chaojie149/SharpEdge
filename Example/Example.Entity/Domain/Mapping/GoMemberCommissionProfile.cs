using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberCommissionProfile
    : AutoMapper.Profile
{
    public GoMemberCommissionProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberCommission, Example.Entity.Domain.Models.GoMemberCommissionReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCommissionCreateModel, Example.Entity.Data.Entities.GoMemberCommission>();

        CreateMap<Example.Entity.Data.Entities.GoMemberCommission, Example.Entity.Domain.Models.GoMemberCommissionCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberCommission, Example.Entity.Domain.Models.GoMemberCommissionUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCommissionUpdateModel, Example.Entity.Data.Entities.GoMemberCommission>();

        CreateMap<Example.Entity.Domain.Models.GoMemberCommissionReadModel, Example.Entity.Domain.Models.GoMemberCommissionUpdateModel>();

    }

}
