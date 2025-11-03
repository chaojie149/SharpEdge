using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoEgglotterAwardMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoEgglotterAward>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoEgglotterAward> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_egglotter_award");

        // key
        builder.HasKey(t => t.AwardId);

        // properties
        builder.Property(t => t.AwardId)
            .IsRequired()
            .HasColumnName("award_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.UserId)
            .HasColumnName("user_id")
            .HasColumnType("int");

        builder.Property(t => t.UserName)
            .HasColumnName("user_name")
            .HasColumnType("varchar(11)")
            .HasMaxLength(11);

        builder.Property(t => t.RuleId)
            .HasColumnName("rule_id")
            .HasColumnType("int");

        builder.Property(t => t.Subtime)
            .HasColumnName("subtime")
            .HasColumnType("int");

        builder.Property(t => t.SpoilId)
            .HasColumnName("spoil_id")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_egglotter_award";
    }

    public readonly struct Columns
    {
        public const string AwardId = "award_id";
        public const string UserId = "user_id";
        public const string UserName = "user_name";
        public const string RuleId = "rule_id";
        public const string Subtime = "subtime";
        public const string SpoilId = "spoil_id";
    }
    #endregion
}
