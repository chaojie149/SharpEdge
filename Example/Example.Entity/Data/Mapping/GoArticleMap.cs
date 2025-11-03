using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoArticleMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoArticle>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoArticle> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_article");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Cateid)
            .IsRequired()
            .HasColumnName("cateid")
            .HasColumnType("char(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Author)
            .HasColumnName("author")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        builder.Property(t => t.TitleStyle)
            .HasColumnName("title_style")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Thumb)
            .HasColumnName("thumb")
            .HasColumnType("char(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Picarr)
            .HasColumnName("picarr")
            .HasColumnType("text");

        builder.Property(t => t.Keywords)
            .HasColumnName("keywords")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Content)
            .HasColumnName("content")
            .HasColumnType("longtext");

        builder.Property(t => t.Hit)
            .HasColumnName("hit")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Order)
            .HasColumnName("order")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Posttime)
            .HasColumnName("posttime")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Language)
            .IsRequired()
            .HasColumnName("language")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_article";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Cateid = "cateid";
        public const string Author = "author";
        public const string Title = "title";
        public const string TitleStyle = "title_style";
        public const string Thumb = "thumb";
        public const string Picarr = "picarr";
        public const string Keywords = "keywords";
        public const string Description = "description";
        public const string Content = "content";
        public const string Hit = "hit";
        public const string Order = "order";
        public const string Posttime = "posttime";
        public const string Language = "language";
    }
    #endregion
}
