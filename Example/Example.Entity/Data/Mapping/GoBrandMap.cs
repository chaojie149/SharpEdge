using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoBrandMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoBrand>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoBrand> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_brand");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Cateid)
            .HasColumnName("cateid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'Y'");

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Order)
            .HasColumnName("order")
            .HasColumnType("int")
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_brand";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Cateid = "cateid";
        public const string Status = "status";
        public const string Name = "name";
        public const string Order = "order";
    }
    #endregion
}
