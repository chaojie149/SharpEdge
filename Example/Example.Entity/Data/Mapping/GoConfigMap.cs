using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoConfigMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoConfig>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoConfig> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_config");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Value)
            .HasColumnName("value")
            .HasColumnType("mediumtext");

        builder.Property(t => t.Zhushi)
            .HasColumnName("zhushi")
            .HasColumnType("text");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_config";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Name = "name";
        public const string Value = "value";
        public const string Zhushi = "zhushi";
    }
    #endregion
}
