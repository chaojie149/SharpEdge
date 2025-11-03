using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWapMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWap>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWap> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_wap");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Language)
            .HasColumnName("language")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Link)
            .HasColumnName("link")
            .HasColumnType("char(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Img)
            .HasColumnName("img")
            .HasColumnType("text");

        builder.Property(t => t.Video)
            .HasColumnName("video")
            .HasColumnType("text");

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Type)
            .HasColumnName("type")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Sort)
            .IsRequired()
            .HasColumnName("sort")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_wap";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Language = "language";
        public const string Title = "title";
        public const string Link = "link";
        public const string Img = "img";
        public const string Video = "video";
        public const string Status = "status";
        public const string Type = "type";
        public const string Sort = "sort";
    }
    #endregion
}
