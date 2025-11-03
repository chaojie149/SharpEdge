using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCardRechargeMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCardRecharge>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCardRecharge> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_card_recharge");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Uid)
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Money)
            .HasColumnName("money")
            .HasColumnType("bigint unsigned");

        builder.Property(t => t.Code)
            .HasColumnName("code")
            .HasColumnType("varchar(21)")
            .HasMaxLength(21);

        builder.Property(t => t.Codepwd)
            .HasColumnName("codepwd")
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Isrepeat)
            .HasColumnName("isrepeat")
            .HasColumnType("varchar(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        builder.Property(t => t.Rechargecount)
            .HasColumnName("rechargecount")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Maxrechargecout)
            .HasColumnName("maxrechargecout")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Rechargetime)
            .HasColumnName("rechargetime")
            .HasColumnType("int");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_card_recharge";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Money = "money";
        public const string Code = "code";
        public const string Codepwd = "codepwd";
        public const string Isrepeat = "isrepeat";
        public const string Rechargecount = "rechargecount";
        public const string Maxrechargecout = "maxrechargecout";
        public const string Rechargetime = "rechargetime";
        public const string Time = "time";
    }
    #endregion
}
