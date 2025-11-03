using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoEgglotterRuleMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoEgglotterRule>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoEgglotterRule> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_egglotter_rule");

        // key
        builder.HasKey(t => t.RuleId);

        // properties
        builder.Property(t => t.RuleId)
            .IsRequired()
            .HasColumnName("rule_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.RuleName)
            .HasColumnName("rule_name")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.Starttime)
            .HasColumnName("starttime")
            .HasColumnType("int");

        builder.Property(t => t.Endtime)
            .HasColumnName("endtime")
            .HasColumnType("int");

        builder.Property(t => t.Subtime)
            .HasColumnName("subtime")
            .HasColumnType("int");

        builder.Property(t => t.Lotterytype)
            .HasColumnName("lotterytype")
            .HasColumnType("int");

        builder.Property(t => t.Lotterjb)
            .HasColumnName("lotterjb")
            .HasColumnType("int");

        builder.Property(t => t.Ruledesc)
            .HasColumnName("ruledesc")
            .HasColumnType("text");

        builder.Property(t => t.Startusing)
            .HasColumnName("startusing")
            .HasColumnType("tinyint");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_egglotter_rule";
    }

    public readonly struct Columns
    {
        public const string RuleId = "rule_id";
        public const string RuleName = "rule_name";
        public const string Starttime = "starttime";
        public const string Endtime = "endtime";
        public const string Subtime = "subtime";
        public const string Lotterytype = "lotterytype";
        public const string Lotterjb = "lotterjb";
        public const string Ruledesc = "ruledesc";
        public const string Startusing = "startusing";
    }
    #endregion
}
