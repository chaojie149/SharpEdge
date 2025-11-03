using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoAdminProfile
    : AutoMapper.Profile
{
    public GoAdminProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoAdmin, Example.Entity.Domain.Models.GoAdminReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdminCreateModel, Example.Entity.Data.Entities.GoAdmin>();

        CreateMap<Example.Entity.Data.Entities.GoAdmin, Example.Entity.Domain.Models.GoAdminCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoAdmin, Example.Entity.Domain.Models.GoAdminUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdminUpdateModel, Example.Entity.Data.Entities.GoAdmin>();

        CreateMap<Example.Entity.Domain.Models.GoAdminReadModel, Example.Entity.Domain.Models.GoAdminUpdateModel>();

    }

}
