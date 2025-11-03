using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberCommissionMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberCommission>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberCommission> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_commission");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Rebateid)
            .IsRequired()
            .HasColumnName("rebateid")
            .HasColumnType("int");

        builder.Property(t => t.TotalMoney)
            .HasColumnName("total_money")
            .HasColumnType("decimal(12,2)")
            .HasDefaultValueSql("'0.00'");

        builder.Property(t => t.ZhichuMoney)
            .HasColumnName("zhichu_money")
            .HasColumnType("decimal(12,2)")
            .HasDefaultValueSql("'0.00'");

        builder.Property(t => t.ShouruMoney)
            .HasColumnName("shouru_money")
            .HasColumnType("decimal(12,2)")
            .HasDefaultValueSql("'0.00'");

        builder.Property(t => t.DongjieMoney)
            .HasColumnName("dongjie_money")
            .HasColumnType("decimal(12,2)")
            .HasDefaultValueSql("'0.00'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_commission";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Rebateid = "rebateid";
        public const string TotalMoney = "total_money";
        public const string ZhichuMoney = "zhichu_money";
        public const string ShouruMoney = "shouru_money";
        public const string DongjieMoney = "dongjie_money";
    }
    #endregion
}
