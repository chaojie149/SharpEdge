using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberBindPhoneProfile
    : AutoMapper.Profile
{
    public GoMemberBindPhoneProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberBindPhone, Example.Entity.Domain.Models.GoMemberBindPhoneReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBindPhoneCreateModel, Example.Entity.Data.Entities.GoMemberBindPhone>();

        CreateMap<Example.Entity.Data.Entities.GoMemberBindPhone, Example.Entity.Domain.Models.GoMemberBindPhoneCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberBindPhone, Example.Entity.Domain.Models.GoMemberBindPhoneUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBindPhoneUpdateModel, Example.Entity.Data.Entities.GoMemberBindPhone>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBindPhoneReadModel, Example.Entity.Domain.Models.GoMemberBindPhoneUpdateModel>();

    }

}
