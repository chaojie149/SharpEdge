using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoNavigationMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoNavigation>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoNavigation> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_navigation");

        // key
        builder.HasKey(t => t.Cid);

        // properties
        builder.Property(t => t.Cid)
            .IsRequired()
            .HasColumnName("cid")
            .HasColumnType("smallint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Parentid)
            .IsRequired()
            .HasColumnName("parentid")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Type)
            .HasColumnName("type")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Url)
            .HasColumnName("url")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'Y'");

        builder.Property(t => t.Order)
            .HasColumnName("order")
            .HasColumnType("smallint unsigned")
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_navigation";
    }

    public readonly struct Columns
    {
        public const string Cid = "cid";
        public const string Parentid = "parentid";
        public const string Name = "name";
        public const string Type = "type";
        public const string Url = "url";
        public const string Status = "status";
        public const string Order = "order";
    }
    #endregion
}
