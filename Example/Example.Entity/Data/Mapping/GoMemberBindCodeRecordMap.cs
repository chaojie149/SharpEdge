using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberBindCodeRecordMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberBindCodeRecord>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberBindCodeRecord> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_bind_code_record");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Phone)
            .HasColumnName("phone")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Updatetime)
            .HasColumnName("updatetime")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.Code)
            .HasColumnName("code")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_bind_code_record";
    }

    public readonly struct Columns
    {
        public const string Phone = "phone";
        public const string Updatetime = "updatetime";
        public const string Code = "code";
    }
    #endregion
}
