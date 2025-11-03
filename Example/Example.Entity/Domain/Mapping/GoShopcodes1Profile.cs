using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoShopcodes1Profile
    : AutoMapper.Profile
{
    public GoShopcodes1Profile()
    {
        CreateMap<Example.Entity.Data.Entities.GoShopcodes1, Example.Entity.Domain.Models.GoShopcodes1ReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoShopcodes1CreateModel, Example.Entity.Data.Entities.GoShopcodes1>();

        CreateMap<Example.Entity.Data.Entities.GoShopcodes1, Example.Entity.Domain.Models.GoShopcodes1CreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoShopcodes1, Example.Entity.Domain.Models.GoShopcodes1UpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoShopcodes1UpdateModel, Example.Entity.Data.Entities.GoShopcodes1>();

        CreateMap<Example.Entity.Domain.Models.GoShopcodes1ReadModel, Example.Entity.Domain.Models.GoShopcodes1UpdateModel>();

    }

}
