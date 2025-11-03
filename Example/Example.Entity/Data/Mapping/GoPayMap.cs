using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoPayMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoPay>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoPay> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_pay");

        // key
        builder.HasKey(t => t.PayId);

        // properties
        builder.Property(t => t.PayId)
            .IsRequired()
            .HasColumnName("pay_id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.PayName)
            .IsRequired()
            .HasColumnName("pay_name")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.PayBank)
            .HasColumnName("pay_bank")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.PayClass)
            .IsRequired()
            .HasColumnName("pay_class")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.PayType)
            .IsRequired()
            .HasColumnName("pay_type")
            .HasColumnType("tinyint");

        builder.Property(t => t.PayThumb)
            .HasColumnName("pay_thumb")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.PayDes)
            .HasColumnName("pay_des")
            .HasColumnType("text");

        builder.Property(t => t.PayStart)
            .IsRequired()
            .HasColumnName("pay_start")
            .HasColumnType("tinyint");

        builder.Property(t => t.PayKey)
            .HasColumnName("pay_key")
            .HasColumnType("text");

        builder.Property(t => t.PayMobile)
            .IsRequired()
            .HasColumnName("pay_mobile")
            .HasColumnType("tinyint unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_pay";
    }

    public readonly struct Columns
    {
        public const string PayId = "pay_id";
        public const string PayName = "pay_name";
        public const string PayBank = "pay_bank";
        public const string PayClass = "pay_class";
        public const string PayType = "pay_type";
        public const string PayThumb = "pay_thumb";
        public const string PayDes = "pay_des";
        public const string PayStart = "pay_start";
        public const string PayKey = "pay_key";
        public const string PayMobile = "pay_mobile";
    }
    #endregion
}
