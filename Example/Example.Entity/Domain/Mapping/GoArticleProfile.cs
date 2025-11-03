using System;

using AutoMapper;

using Example.Entity.Data.Entities;
using Example.Entity.Domain.Models;

namespace Example.Entity.Domain.Mapping;

public partial class GoArticleProfile
    : AutoMapper.Profile
{
    public GoArticleProfile()
    {
        CreateMap<Example.Entity.Data.Entities.GoArticle, Example.Entity.Domain.Models.GoArticleReadModel>();

        CreateMap<Example.Entity.Domain.Models.GoArticleCreateModel, Example.Entity.Data.Entities.GoArticle>();

        CreateMap<Example.Entity.Data.Entities.GoArticle, Example.Entity.Domain.Models.GoArticleCreateModel>();

        CreateMap<Example.Entity.Data.Entities.GoArticle, Example.Entity.Domain.Models.GoArticleUpdateModel>();

        CreateMap<Example.Entity.Domain.Models.GoArticleUpdateModel, Example.Entity.Data.Entities.GoArticle>();

        CreateMap<Example.Entity.Domain.Models.GoArticleReadModel, Example.Entity.Domain.Models.GoArticleUpdateModel>();

    }

}
