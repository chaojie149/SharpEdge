using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoAdminUsergroupProfile
    : AutoMapper.Profile
{
    public GoAdminUsergroupProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoAdminUsergroup, Example.Entity.Domain.Models.GoAdminUsergroupReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdminUsergroupCreateModel, Example.Entity.Data.Entities.GoAdminUsergroup>();

        CreateMap<Example.Entity.Data.Entities.GoAdminUsergroup, Example.Entity.Domain.Models.GoAdminUsergroupCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoAdminUsergroup, Example.Entity.Domain.Models.GoAdminUsergroupUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoAdminUsergroupUpdateModel, Example.Entity.Data.Entities.GoAdminUsergroup>();

        CreateMap<Example.Entity.Domain.Models.GoAdminUsergroupReadModel, Example.Entity.Domain.Models.GoAdminUsergroupUpdateModel>();

    }

}
