using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoQqsetMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoQqset>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoQqset> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_qqset");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Qq)
            .HasColumnName("qq")
            .HasColumnType("text");

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("text");

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Qqurl)
            .HasColumnName("qqurl")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Full)
            .IsRequired()
            .HasColumnName("full")
            .HasColumnType("char(10)")
            .HasMaxLength(10)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Province)
            .HasColumnName("province")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.City)
            .HasColumnName("city")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.County)
            .HasColumnName("county")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Subtime)
            .HasColumnName("subtime")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_qqset";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Qq = "qq";
        public const string Name = "name";
        public const string Type = "type";
        public const string Qqurl = "qqurl";
        public const string Full = "full";
        public const string Province = "province";
        public const string City = "city";
        public const string County = "county";
        public const string Subtime = "subtime";
    }
    #endregion
}
