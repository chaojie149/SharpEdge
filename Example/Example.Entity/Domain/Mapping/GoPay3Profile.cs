using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoPay3Profile
    : AutoMapper.Profile
{
    public GoPay3Profile()
    {
        CreateMap<Example.Entity.Data.Entities.GoPay3, Example.Entity.Domain.Models.GoPay3ReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoPay3CreateModel, Example.Entity.Data.Entities.GoPay3>();

        CreateMap<Example.Entity.Data.Entities.GoPay3, Example.Entity.Domain.Models.GoPay3CreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoPay3, Example.Entity.Domain.Models.GoPay3UpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoPay3UpdateModel, Example.Entity.Data.Entities.GoPay3>();

        CreateMap<Example.Entity.Domain.Models.GoPay3ReadModel, Example.Entity.Domain.Models.GoPay3UpdateModel>();

    }

}
