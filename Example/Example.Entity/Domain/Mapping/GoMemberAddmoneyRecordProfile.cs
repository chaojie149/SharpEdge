using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoMemberAddmoneyRecordProfile
    : AutoMapper.Profile
{
    public GoMemberAddmoneyRecordProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoMemberAddmoneyRecord, Example.Entity.Domain.Models.GoMemberAddmoneyRecordReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberAddmoneyRecordCreateModel, Example.Entity.Data.Entities.GoMemberAddmoneyRecord>();

        CreateMap<Example.Entity.Data.Entities.GoMemberAddmoneyRecord, Example.Entity.Domain.Models.GoMemberAddmoneyRecordCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoMemberAddmoneyRecord, Example.Entity.Domain.Models.GoMemberAddmoneyRecordUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoMemberAddmoneyRecordUpdateModel, Example.Entity.Data.Entities.GoMemberAddmoneyRecord>();

        CreateMap<Example.Entity.Domain.Models.GoMemberAddmoneyRecordReadModel, Example.Entity.Domain.Models.GoMemberAddmoneyRecordUpdateModel>();

    }

}
