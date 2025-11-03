using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoAppointProfile
    : AutoMapper.Profile
{
    public GoAppointProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoAppoint, Example.Entity.Domain.Models.GoAppointReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoAppointCreateModel, Example.Entity.Data.Entities.GoAppoint>();

        CreateMap<Example.Entity.Data.Entities.GoAppoint, Example.Entity.Domain.Models.GoAppointCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoAppoint, Example.Entity.Domain.Models.GoAppointUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoAppointUpdateModel, Example.Entity.Data.Entities.GoAppoint>();

        CreateMap<Example.Entity.Domain.Models.GoAppointReadModel, Example.Entity.Domain.Models.GoAppointUpdateModel>();

    }

}
