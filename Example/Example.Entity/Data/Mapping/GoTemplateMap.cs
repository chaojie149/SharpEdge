using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoTemplateMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoTemplate>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoTemplate> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_template");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.TemplateName)
            .IsRequired()
            .HasColumnName("template_name")
            .HasColumnType("char(25)")
            .HasMaxLength(25);

        builder.Property(t => t.Template)
            .IsRequired()
            .HasColumnName("template")
            .HasColumnType("char(25)")
            .HasMaxLength(25);

        builder.Property(t => t.Des)
            .HasColumnName("des")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_template";
    }

    public readonly struct Columns
    {
        public const string TemplateName = "template_name";
        public const string Template = "template";
        public const string Des = "des";
    }
    #endregion
}
