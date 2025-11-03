using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMobileVerifyProfile
    : AutoMapper.Profile
{
    public GoMobileVerifyProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMobileVerify, Example.Entity.Domain.Models.GoMobileVerifyReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMobileVerifyCreateModel, Example.Entity.Data.Entities.GoMobileVerify>();

        CreateMap<Example.Entity.Data.Entities.GoMobileVerify, Example.Entity.Domain.Models.GoMobileVerifyCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMobileVerify, Example.Entity.Domain.Models.GoMobileVerifyUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMobileVerifyUpdateModel, Example.Entity.Data.Entities.GoMobileVerify>();

        CreateMap<Example.Entity.Domain.Models.GoMobileVerifyReadModel, Example.Entity.Domain.Models.GoMobileVerifyUpdateModel>();

    }

}
