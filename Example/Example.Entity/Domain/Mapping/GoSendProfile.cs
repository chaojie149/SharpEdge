using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoSendProfile
    : AutoMapper.Profile
{
    public GoSendProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoSend, Example.Entity.Domain.Models.GoSendReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoSendCreateModel, Example.Entity.Data.Entities.GoSend>();

        CreateMap<Example.Entity.Data.Entities.GoSend, Example.Entity.Domain.Models.GoSendCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoSend, Example.Entity.Domain.Models.GoSendUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoSendUpdateModel, Example.Entity.Data.Entities.GoSend>();

        CreateMap<Example.Entity.Domain.Models.GoSendReadModel, Example.Entity.Domain.Models.GoSendUpdateModel>();

    }

}
