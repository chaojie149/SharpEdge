using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoFundMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoFund>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoFund> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_fund");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.FundOff)
            .IsRequired()
            .HasColumnName("fund_off")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.FundMoney)
            .IsRequired()
            .HasColumnName("fund_money")
            .HasColumnType("decimal(10,2)");

        builder.Property(t => t.FundCountMoney)
            .HasColumnName("fund_count_money")
            .HasColumnType("decimal(12,2)");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_fund";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string FundOff = "fund_off";
        public const string FundMoney = "fund_money";
        public const string FundCountMoney = "fund_count_money";
    }
    #endregion
}
