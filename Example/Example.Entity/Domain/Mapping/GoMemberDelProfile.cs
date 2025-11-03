using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberDelProfile
    : AutoMapper.Profile
{
    public GoMemberDelProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberDel, Example.Entity.Domain.Models.GoMemberDelReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberDelCreateModel, Example.Entity.Data.Entities.GoMemberDel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberDel, Example.Entity.Domain.Models.GoMemberDelCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberDel, Example.Entity.Domain.Models.GoMemberDelUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberDelUpdateModel, Example.Entity.Data.Entities.GoMemberDel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberDelReadModel, Example.Entity.Domain.Models.GoMemberDelUpdateModel>();

    }

}
