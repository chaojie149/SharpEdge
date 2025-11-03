using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoCardPwdProfile
    : AutoMapper.Profile
{
    public GoCardPwdProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoCardPwd, Example.Entity.Domain.Models.GoCardPwdReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoCardPwdCreateModel, Example.Entity.Data.Entities.GoCardPwd>();

        CreateMap<Example.Entity.Data.Entities.GoCardPwd, Example.Entity.Domain.Models.GoCardPwdCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoCardPwd, Example.Entity.Domain.Models.GoCardPwdUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoCardPwdUpdateModel, Example.Entity.Data.Entities.GoCardPwd>();

        CreateMap<Example.Entity.Domain.Models.GoCardPwdReadModel, Example.Entity.Domain.Models.GoCardPwdUpdateModel>();

    }

}
