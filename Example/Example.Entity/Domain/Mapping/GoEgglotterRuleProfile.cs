using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoEgglotterRuleProfile
    : AutoMapper.Profile
{
    public GoEgglotterRuleProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoEgglotterRule, Example.Entity.Domain.Models.GoEgglotterRuleReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterRuleCreateModel, Example.Entity.Data.Entities.GoEgglotterRule>();

        CreateMap<Example.Entity.Data.Entities.GoEgglotterRule, Example.Entity.Domain.Models.GoEgglotterRuleCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoEgglotterRule, Example.Entity.Domain.Models.GoEgglotterRuleUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterRuleUpdateModel, Example.Entity.Data.Entities.GoEgglotterRule>();

        CreateMap<Example.Entity.Domain.Models.GoEgglotterRuleReadModel, Example.Entity.Domain.Models.GoEgglotterRuleUpdateModel>();

    }

}
