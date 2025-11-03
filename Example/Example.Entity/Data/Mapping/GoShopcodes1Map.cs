using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoShopcodes1Map
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoShopcodes1>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoShopcodes1> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_shopcodes_1");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.SId)
            .IsRequired()
            .HasColumnName("s_id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.SCid)
            .IsRequired()
            .HasColumnName("s_cid")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.SLen)
            .HasColumnName("s_len")
            .HasColumnType("smallint");

        builder.Property(t => t.SCodes)
            .HasColumnName("s_codes")
            .HasColumnType("text");

        builder.Property(t => t.SCodesTmp)
            .HasColumnName("s_codes_tmp")
            .HasColumnType("text");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_shopcodes_1";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string SId = "s_id";
        public const string SCid = "s_cid";
        public const string SLen = "s_len";
        public const string SCodes = "s_codes";
        public const string SCodesTmp = "s_codes_tmp";
    }
    #endregion
}
