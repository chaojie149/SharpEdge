using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoEgglotterSpoilMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoEgglotterSpoil>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoEgglotterSpoil> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_egglotter_spoil");

        // key
        builder.HasKey(t => t.SpoilId);

        // properties
        builder.Property(t => t.SpoilId)
            .IsRequired()
            .HasColumnName("spoil_id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.RuleId)
            .HasColumnName("rule_id")
            .HasColumnType("int");

        builder.Property(t => t.SpoilName)
            .HasColumnName("spoil_name")
            .HasColumnType("text");

        builder.Property(t => t.SpoilJl)
            .HasColumnName("spoil_jl")
            .HasColumnType("int");

        builder.Property(t => t.SpoilDj)
            .HasColumnName("spoil_dj")
            .HasColumnType("int");

        builder.Property(t => t.Urlimg)
            .HasColumnName("urlimg")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.Subtime)
            .HasColumnName("subtime")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_egglotter_spoil";
    }

    public readonly struct Columns
    {
        public const string SpoilId = "spoil_id";
        public const string RuleId = "rule_id";
        public const string SpoilName = "spoil_name";
        public const string SpoilJl = "spoil_jl";
        public const string SpoilDj = "spoil_dj";
        public const string Urlimg = "urlimg";
        public const string Subtime = "subtime";
    }
    #endregion
}
