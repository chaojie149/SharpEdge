using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoRecomMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoRecom>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoRecom> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_recom");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(t => t.Img)
            .HasColumnName("img")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Link)
            .HasColumnName("link")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_recom";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Img = "img";
        public const string Title = "title";
        public const string Link = "link";
    }
    #endregion
}
