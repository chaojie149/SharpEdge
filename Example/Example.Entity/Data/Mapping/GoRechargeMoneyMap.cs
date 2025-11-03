using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoRechargeMoneyMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoRechargeMoney>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoRechargeMoney> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_recharge_money");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("tinyint");

        builder.Property(t => t.Uid)
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("char(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Dindancode)
            .HasColumnName("dindancode")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Day)
            .IsRequired()
            .HasColumnName("day")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_recharge_money";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Time = "time";
        public const string Dindancode = "dindancode";
        public const string Status = "status";
        public const string Day = "day";
    }
    #endregion
}
