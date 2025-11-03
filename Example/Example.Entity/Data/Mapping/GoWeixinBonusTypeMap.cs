using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinBonusTypeMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinBonusType>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinBonusType> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_bonus_type");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.TypeId)
            .IsRequired()
            .HasColumnName("type_id")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.TypeName)
            .IsRequired()
            .HasColumnName("type_name")
            .HasColumnType("varchar(60)")
            .HasMaxLength(60)
            .HasDefaultValueSql("''");

        builder.Property(t => t.TypeMoney)
            .IsRequired()
            .HasColumnName("type_money")
            .HasColumnType("decimal(10,2)");

        builder.Property(t => t.SendType)
            .IsRequired()
            .HasColumnName("send_type")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.SendStartDate)
            .IsRequired()
            .HasColumnName("send_start_date")
            .HasColumnType("int");

        builder.Property(t => t.SendEndDate)
            .IsRequired()
            .HasColumnName("send_end_date")
            .HasColumnType("int");

        builder.Property(t => t.Total)
            .IsRequired()
            .HasColumnName("total")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Getnum)
            .IsRequired()
            .HasColumnName("getnum")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_bonus_type";
    }

    public readonly struct Columns
    {
        public const string TypeId = "type_id";
        public const string TypeName = "type_name";
        public const string TypeMoney = "type_money";
        public const string SendType = "send_type";
        public const string SendStartDate = "send_start_date";
        public const string SendEndDate = "send_end_date";
        public const string Total = "total";
        public const string Getnum = "getnum";
    }
    #endregion
}
