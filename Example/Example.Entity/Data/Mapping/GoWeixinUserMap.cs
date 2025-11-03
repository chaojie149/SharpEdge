using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinUserMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinUser>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinUser> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_user");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Subscribe)
            .IsRequired()
            .HasColumnName("subscribe")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Wxid)
            .IsRequired()
            .HasColumnName("wxid")
            .HasColumnType("char(28)")
            .HasMaxLength(28);

        builder.Property(t => t.Nickname)
            .IsRequired()
            .HasColumnName("nickname")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.Sex)
            .IsRequired()
            .HasColumnName("sex")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.City)
            .IsRequired()
            .HasColumnName("city")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Country)
            .IsRequired()
            .HasColumnName("country")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Typeid)
            .IsRequired()
            .HasColumnName("typeid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Headimgurl)
            .IsRequired()
            .HasColumnName("headimgurl")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.SubscribeTime)
            .IsRequired()
            .HasColumnName("subscribe_time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Localimgurl)
            .IsRequired()
            .HasColumnName("localimgurl")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.Setp)
            .IsRequired()
            .HasColumnName("setp")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Uname)
            .IsRequired()
            .HasColumnName("uname")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Coupon)
            .IsRequired()
            .HasColumnName("coupon")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_user";
    }

    public readonly struct Columns
    {
        public const string Uid = "uid";
        public const string Subscribe = "subscribe";
        public const string Wxid = "wxid";
        public const string Nickname = "nickname";
        public const string Sex = "sex";
        public const string City = "city";
        public const string Country = "country";
        public const string Time = "time";
        public const string Typeid = "typeid";
        public const string Headimgurl = "headimgurl";
        public const string SubscribeTime = "subscribe_time";
        public const string Localimgurl = "localimgurl";
        public const string Setp = "setp";
        public const string Uname = "uname";
        public const string Coupon = "coupon";
    }
    #endregion
}
