using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberBandMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberBand>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberBand> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_band");

        // key
        builder.HasKey(t => t.BId);

        // properties
        builder.Property(t => t.BId)
            .IsRequired()
            .HasColumnName("b_id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.BUid)
            .HasColumnName("b_uid")
            .HasColumnType("int");

        builder.Property(t => t.BType)
            .HasColumnName("b_type")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.BCode)
            .HasColumnName("b_code")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.BData)
            .HasColumnName("b_data")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.BTime)
            .HasColumnName("b_time")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_band";
    }

    public readonly struct Columns
    {
        public const string BId = "b_id";
        public const string BUid = "b_uid";
        public const string BType = "b_type";
        public const string BCode = "b_code";
        public const string BData = "b_data";
        public const string BTime = "b_time";
    }
    #endregion
}
