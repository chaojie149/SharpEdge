using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberOrderaddressBrandProfile
    : AutoMapper.Profile
{
    public GoMemberOrderaddressBrandProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberOrderaddressBrand, Example.Entity.Domain.Models.GoMemberOrderaddressBrandReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberOrderaddressBrandCreateModel, Example.Entity.Data.Entities.GoMemberOrderaddressBrand>();

        CreateMap<Example.Entity.Data.Entities.GoMemberOrderaddressBrand, Example.Entity.Domain.Models.GoMemberOrderaddressBrandCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberOrderaddressBrand, Example.Entity.Domain.Models.GoMemberOrderaddressBrandUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberOrderaddressBrandUpdateModel, Example.Entity.Data.Entities.GoMemberOrderaddressBrand>();

        CreateMap<Example.Entity.Domain.Models.GoMemberOrderaddressBrandReadModel, Example.Entity.Domain.Models.GoMemberOrderaddressBrandUpdateModel>();

    }

}
