using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberBindPhoneMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberBindPhone>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberBindPhone> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_bind_phone");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("bigint");

        builder.Property(t => t.Phone)
            .HasColumnName("phone")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Intime)
            .HasColumnName("intime")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_bind_phone";
    }

    public readonly struct Columns
    {
        public const string Uid = "uid";
        public const string Phone = "phone";
        public const string Intime = "intime";
    }
    #endregion
}
