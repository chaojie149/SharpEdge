using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberBindCodeRecordProfile
    : AutoMapper.Profile
{
    public GoMemberBindCodeRecordProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberBindCodeRecord, Example.Entity.Domain.Models.GoMemberBindCodeRecordReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBindCodeRecordCreateModel, Example.Entity.Data.Entities.GoMemberBindCodeRecord>();

        CreateMap<Example.Entity.Data.Entities.GoMemberBindCodeRecord, Example.Entity.Domain.Models.GoMemberBindCodeRecordCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberBindCodeRecord, Example.Entity.Domain.Models.GoMemberBindCodeRecordUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBindCodeRecordUpdateModel, Example.Entity.Data.Entities.GoMemberBindCodeRecord>();

        CreateMap<Example.Entity.Domain.Models.GoMemberBindCodeRecordReadModel, Example.Entity.Domain.Models.GoMemberBindCodeRecordUpdateModel>();

    }

}
