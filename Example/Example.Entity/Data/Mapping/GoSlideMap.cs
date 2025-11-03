using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoSlideMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoSlide>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoSlide> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_slide");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

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
            .HasMaxLength(255);

        builder.Property(t => t.Way)
            .HasColumnName("way")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_slide";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Img = "img";
        public const string Title = "title";
        public const string Link = "link";
        public const string Way = "way";
    }
    #endregion
}
