using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoAdAreaMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoAdArea>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoAdArea> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_ad_area");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Width)
            .HasColumnName("width")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Height)
            .HasColumnName("height")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Des)
            .HasColumnName("des")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Checked)
            .HasColumnName("checked")
            .HasColumnType("tinyint(1)")
            .HasDefaultValueSql("'0'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_ad_area";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Title = "title";
        public const string Width = "width";
        public const string Height = "height";
        public const string Des = "des";
        public const string Checked = "checked";
    }
    #endregion
}
