using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoSlideProfile
    : AutoMapper.Profile
{
    public GoSlideProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoSlide, Example.Entity.Domain.Models.GoSlideReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoSlideCreateModel, Example.Entity.Data.Entities.GoSlide>();

        CreateMap<Example.Entity.Data.Entities.GoSlide, Example.Entity.Domain.Models.GoSlideCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoSlide, Example.Entity.Domain.Models.GoSlideUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoSlideUpdateModel, Example.Entity.Data.Entities.GoSlide>();

        CreateMap<Example.Entity.Domain.Models.GoSlideReadModel, Example.Entity.Domain.Models.GoSlideUpdateModel>();

    }

}
