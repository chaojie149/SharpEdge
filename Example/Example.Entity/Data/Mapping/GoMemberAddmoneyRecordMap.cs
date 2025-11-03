using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberAddmoneyRecordMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberAddmoneyRecord>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberAddmoneyRecord> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_addmoney_record");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Code)
            .IsRequired()
            .HasColumnName("code")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Money)
            .IsRequired()
            .HasColumnName("money")
            .HasColumnType("decimal(10,2)");

        builder.Property(t => t.PayType)
            .IsRequired()
            .HasColumnName("pay_type")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int");

        builder.Property(t => t.Score)
            .IsRequired()
            .HasColumnName("score")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Scookies)
            .HasColumnName("scookies")
            .HasColumnType("text");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_addmoney_record";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Code = "code";
        public const string Money = "money";
        public const string PayType = "pay_type";
        public const string Status = "status";
        public const string Time = "time";
        public const string Score = "score";
        public const string Scookies = "scookies";
    }
    #endregion
}
