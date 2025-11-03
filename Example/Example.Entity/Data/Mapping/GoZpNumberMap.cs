using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoZpNumberMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoZpNumber>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoZpNumber> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_zp_number");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Number)
            .HasColumnName("number")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.HasNum)
            .IsRequired()
            .HasColumnName("has_num")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_zp_number";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Number = "number";
        public const string Time = "time";
        public const string HasNum = "has_num";
    }
    #endregion
}
