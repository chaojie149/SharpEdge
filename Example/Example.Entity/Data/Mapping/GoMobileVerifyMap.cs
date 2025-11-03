using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMobileVerifyMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMobileVerify>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMobileVerify> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_mobile_verify");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Mobile)
            .HasColumnName("mobile")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Verify)
            .IsRequired()
            .HasColumnName("verify")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_mobile_verify";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Mobile = "mobile";
        public const string Verify = "verify";
        public const string Time = "time";
    }
    #endregion
}
