using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCzkMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCzk>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCzk> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_czk");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Czknum)
            .IsRequired()
            .HasColumnName("czknum")
            .HasColumnType("varchar(12)")
            .HasMaxLength(12);

        builder.Property(t => t.Password)
            .IsRequired()
            .HasColumnName("password")
            .HasColumnType("varchar(12)")
            .HasMaxLength(12);

        builder.Property(t => t.Mianzhi)
            .IsRequired()
            .HasColumnName("mianzhi")
            .HasColumnType("int");

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Ewm)
            .IsRequired()
            .HasColumnName("ewm")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Address)
            .IsRequired()
            .HasColumnName("address")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_czk";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Czknum = "czknum";
        public const string Password = "password";
        public const string Mianzhi = "mianzhi";
        public const string Status = "status";
        public const string Type = "type";
        public const string Ewm = "ewm";
        public const string Address = "address";
    }
    #endregion
}
