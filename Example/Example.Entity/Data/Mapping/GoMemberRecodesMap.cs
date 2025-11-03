using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberRecodesMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberRecodes>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberRecodes> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_recodes");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Rebateid)
            .IsRequired()
            .HasColumnName("rebateid")
            .HasColumnType("int");

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.Content)
            .IsRequired()
            .HasColumnName("content")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Shopid)
            .HasColumnName("shopid")
            .HasColumnType("int");

        builder.Property(t => t.Money)
            .IsRequired()
            .HasColumnName("money")
            .HasColumnType("decimal(12,2)");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Ygmoney)
            .IsRequired()
            .HasColumnName("ygmoney")
            .HasColumnType("decimal(8,2)");

        builder.Property(t => t.Cashoutid)
            .HasColumnName("cashoutid")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_recodes";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Rebateid = "rebateid";
        public const string Uid = "uid";
        public const string Type = "type";
        public const string Content = "content";
        public const string Shopid = "shopid";
        public const string Money = "money";
        public const string Time = "time";
        public const string Ygmoney = "ygmoney";
        public const string Cashoutid = "cashoutid";
    }
    #endregion
}
