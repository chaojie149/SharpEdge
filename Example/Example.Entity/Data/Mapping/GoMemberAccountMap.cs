using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberAccountMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberAccount>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberAccount> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_account");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Type)
            .HasColumnName("type")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.Pay)
            .HasColumnName("pay")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Content)
            .HasColumnName("content")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Money)
            .IsRequired()
            .HasColumnName("money")
            .HasColumnType("bigint");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_account";
    }

    public readonly struct Columns
    {
        public const string Uid = "uid";
        public const string Type = "type";
        public const string Pay = "pay";
        public const string Content = "content";
        public const string Money = "money";
        public const string Time = "time";
    }
    #endregion
}
