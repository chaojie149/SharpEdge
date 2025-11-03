using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCjcodeMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCjcode>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCjcode> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_cjcode");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Code)
            .IsRequired()
            .HasColumnName("code")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Scenename)
            .IsRequired()
            .HasColumnName("scenename")
            .HasColumnType("char(50)")
            .HasMaxLength(50)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Ticket)
            .IsRequired()
            .HasColumnName("ticket")
            .HasColumnType("char(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Total)
            .IsRequired()
            .HasColumnName("total")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Nownum)
            .IsRequired()
            .HasColumnName("nownum")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_cjcode";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Code = "code";
        public const string Scenename = "scenename";
        public const string Ticket = "ticket";
        public const string Time = "time";
        public const string Total = "total";
        public const string Nownum = "nownum";
    }
    #endregion
}
