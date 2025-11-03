using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoLanguageMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoLanguage>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoLanguage> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_language");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.LgValue)
            .IsRequired()
            .HasColumnName("lg_value")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        builder.Property(t => t.LgName)
            .IsRequired()
            .HasColumnName("lg_name")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_language";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string LgValue = "lg_value";
        public const string LgName = "lg_name";
        public const string Status = "status";
    }
    #endregion
}
