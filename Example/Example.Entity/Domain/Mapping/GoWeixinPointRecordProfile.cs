using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoWeixinPointRecordProfile
    : AutoMapper.Profile
{
    public GoWeixinPointRecordProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoWeixinPointRecord, Example.Entity.Domain.Models.GoWeixinPointRecordReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinPointRecordCreateModel, Example.Entity.Data.Entities.GoWeixinPointRecord>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinPointRecord, Example.Entity.Domain.Models.GoWeixinPointRecordCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoWeixinPointRecord, Example.Entity.Domain.Models.GoWeixinPointRecordUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinPointRecordUpdateModel, Example.Entity.Data.Entities.GoWeixinPointRecord>();

        CreateMap<Example.Entity.Domain.Models.GoWeixinPointRecordReadModel, Example.Entity.Domain.Models.GoWeixinPointRecordUpdateModel>();

    }

}
