using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoPayProfile
    : AutoMapper.Profile
{
    public GoPayProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoPay, Example.Entity.Domain.Models.GoPayReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoPayCreateModel, Example.Entity.Data.Entities.GoPay>();

        CreateMap<Example.Entity.Data.Entities.GoPay, Example.Entity.Domain.Models.GoPayCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoPay, Example.Entity.Domain.Models.GoPayUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoPayUpdateModel, Example.Entity.Data.Entities.GoPay>();

        CreateMap<Example.Entity.Domain.Models.GoPayReadModel, Example.Entity.Domain.Models.GoPayUpdateModel>();

    }

}
