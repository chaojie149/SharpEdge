using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberRechangesMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberRechanges>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberRechanges> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_rechanges");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.PayId)
            .IsRequired()
            .HasColumnName("pay_id")
            .HasColumnType("int");

        builder.Property(t => t.Num)
            .IsRequired()
            .HasColumnName("num")
            .HasColumnType("float(12,2)");

        builder.Property(t => t.Oid)
            .IsRequired()
            .HasColumnName("oid")
            .HasColumnType("text");

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("int")
            .HasDefaultValueSql("'3'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_rechanges";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string PayId = "pay_id";
        public const string Num = "num";
        public const string Oid = "oid";
        public const string Uid = "uid";
        public const string Time = "time";
        public const string Type = "type";
    }
    #endregion
}
