using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberGoRecordMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberGoRecord>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberGoRecord> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_go_record");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Code)
            .HasColumnName("code")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.CodeTmp)
            .HasColumnName("code_tmp")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Username)
            .IsRequired()
            .HasColumnName("username")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Uphoto)
            .HasColumnName("uphoto")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Shopid)
            .IsRequired()
            .HasColumnName("shopid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Shopname)
            .IsRequired()
            .HasColumnName("shopname")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Shopqishu)
            .IsRequired()
            .HasColumnName("shopqishu")
            .HasColumnType("smallint");

        builder.Property(t => t.Gonumber)
            .HasColumnName("gonumber")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Goucode)
            .IsRequired()
            .HasColumnName("goucode")
            .HasColumnType("longtext");

        builder.Property(t => t.Moneycount)
            .IsRequired()
            .HasColumnName("moneycount")
            .HasColumnType("bigint");

        builder.Property(t => t.Huode)
            .IsRequired()
            .HasColumnName("huode")
            .HasColumnType("char(50)")
            .HasMaxLength(50)
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.PayType)
            .HasColumnName("pay_type")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Ip)
            .HasColumnName("ip")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("char(30)")
            .HasMaxLength(30);

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("char(21)")
            .HasMaxLength(21);

        builder.Property(t => t.Company)
            .IsRequired()
            .HasColumnName("company")
            .HasColumnType("char(18)")
            .HasMaxLength(18);

        builder.Property(t => t.CompanyCode)
            .IsRequired()
            .HasColumnName("company_code")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.CompanyMoney)
            .IsRequired()
            .HasColumnName("company_money")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Address)
            .IsRequired()
            .HasColumnName("address")
            .HasColumnType("varchar(1024)")
            .HasMaxLength(1024);

        builder.Property(t => t.OrderPhone)
            .IsRequired()
            .HasColumnName("order_phone")
            .HasColumnType("char(11)")
            .HasMaxLength(11);

        builder.Property(t => t.ConfirmAddress)
            .IsRequired()
            .HasColumnName("confirm_address")
            .HasColumnType("tinyint");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_go_record";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Code = "code";
        public const string CodeTmp = "code_tmp";
        public const string Username = "username";
        public const string Uphoto = "uphoto";
        public const string Uid = "uid";
        public const string Shopid = "shopid";
        public const string Shopname = "shopname";
        public const string Shopqishu = "shopqishu";
        public const string Gonumber = "gonumber";
        public const string Goucode = "goucode";
        public const string Moneycount = "moneycount";
        public const string Huode = "huode";
        public const string PayType = "pay_type";
        public const string Ip = "ip";
        public const string Status = "status";
        public const string Time = "time";
        public const string Company = "company";
        public const string CompanyCode = "company_code";
        public const string CompanyMoney = "company_money";
        public const string Address = "address";
        public const string OrderPhone = "order_phone";
        public const string ConfirmAddress = "confirm_address";
    }
    #endregion
}
