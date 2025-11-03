using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberGoRecordProfile
    : AutoMapper.Profile
{
    public GoMemberGoRecordProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberGoRecord, Example.Entity.Domain.Models.GoMemberGoRecordReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberGoRecordCreateModel, Example.Entity.Data.Entities.GoMemberGoRecord>();

        CreateMap<Example.Entity.Data.Entities.GoMemberGoRecord, Example.Entity.Domain.Models.GoMemberGoRecordCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberGoRecord, Example.Entity.Domain.Models.GoMemberGoRecordUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberGoRecordUpdateModel, Example.Entity.Data.Entities.GoMemberGoRecord>();

        CreateMap<Example.Entity.Domain.Models.GoMemberGoRecordReadModel, Example.Entity.Domain.Models.GoMemberGoRecordUpdateModel>();

    }

}
