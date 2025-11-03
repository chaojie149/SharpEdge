using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoQuanziHueifuMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoQuanziHueifu>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoQuanziHueifu> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_quanzi_hueifu");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Tzid)
            .HasColumnName("tzid")
            .HasColumnType("int");

        builder.Property(t => t.Hueifu)
            .HasColumnName("hueifu")
            .HasColumnType("text");

        builder.Property(t => t.Hueiyuan)
            .HasColumnName("hueiyuan")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Hftime)
            .HasColumnName("hftime")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_quanzi_hueifu";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Tzid = "tzid";
        public const string Hueifu = "hueifu";
        public const string Hueiyuan = "hueiyuan";
        public const string Hftime = "hftime";
    }
    #endregion
}
