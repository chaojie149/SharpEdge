using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCachesMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCaches>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCaches> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_caches");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Key)
            .IsRequired()
            .HasColumnName("key")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Value)
            .HasColumnName("value")
            .HasColumnType("text");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_caches";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Key = "key";
        public const string Value = "value";
    }
    #endregion
}
