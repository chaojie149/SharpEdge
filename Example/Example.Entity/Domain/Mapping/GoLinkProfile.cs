using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoLinkProfile
    : AutoMapper.Profile
{
    public GoLinkProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoLink, Example.Entity.Domain.Models.GoLinkReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoLinkCreateModel, Example.Entity.Data.Entities.GoLink>();

        CreateMap<Example.Entity.Data.Entities.GoLink, Example.Entity.Domain.Models.GoLinkCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoLink, Example.Entity.Domain.Models.GoLinkUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoLinkUpdateModel, Example.Entity.Data.Entities.GoLink>();

        CreateMap<Example.Entity.Domain.Models.GoLinkReadModel, Example.Entity.Domain.Models.GoLinkUpdateModel>();

    }

}
