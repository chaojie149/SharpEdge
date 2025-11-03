using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoLinkMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoLink>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoLink> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_link");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Logo)
            .IsRequired()
            .HasColumnName("logo")
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder.Property(t => t.Url)
            .IsRequired()
            .HasColumnName("url")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_link";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Type = "type";
        public const string Name = "name";
        public const string Logo = "logo";
        public const string Url = "url";
    }
    #endregion
}
