using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMember>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMember> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member");

        // key
        builder.HasKey(t => t.Uid);

        // properties
        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Username)
            .IsRequired()
            .HasColumnName("username")
            .HasColumnType("char(20)")
            .HasMaxLength(20)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Email)
            .IsRequired()
            .HasColumnName("email")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Mobile)
            .IsRequired()
            .HasColumnName("mobile")
            .HasColumnType("char(50)")
            .HasMaxLength(50)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Password)
            .HasColumnName("password")
            .HasColumnType("char(32)")
            .HasMaxLength(32);

        builder.Property(t => t.UserIp)
            .HasColumnName("user_ip")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Img)
            .HasColumnName("img")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("'/statics/uploads/photo/member.jpg'");

        builder.Property(t => t.Qianming)
            .HasColumnName("qianming")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Groupid)
            .HasColumnName("groupid")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Addgroup)
            .HasColumnName("addgroup")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Money)
            .HasColumnName("money")
            .HasColumnType("bigint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Emailcode)
            .HasColumnName("emailcode")
            .HasColumnType("char(21)")
            .HasMaxLength(21)
            .HasDefaultValueSql("'-1'");

        builder.Property(t => t.Mobilecode)
            .HasColumnName("mobilecode")
            .HasColumnType("char(21)")
            .HasMaxLength(21)
            .HasDefaultValueSql("'-1'");

        builder.Property(t => t.Othercode)
            .IsRequired()
            .HasColumnName("othercode")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.Passcode)
            .HasColumnName("passcode")
            .HasColumnType("char(21)")
            .HasMaxLength(21)
            .HasDefaultValueSql("'-1'");

        builder.Property(t => t.RegKey)
            .HasColumnName("reg_key")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Score)
            .IsRequired()
            .HasColumnName("score")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Jingyan)
            .HasColumnName("jingyan")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Yaoqing1)
            .HasColumnName("yaoqing1")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Yaoqing1name)
            .HasColumnName("yaoqing1name")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Yaoqing2)
            .HasColumnName("yaoqing2")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Yaoqing2name)
            .HasColumnName("yaoqing2name")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Band)
            .HasColumnName("band")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("int");

        builder.Property(t => t.Headimg)
            .IsRequired()
            .HasColumnName("headimg")
            .HasColumnType("char(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Wxid)
            .HasColumnName("wxid")
            .HasColumnType("char(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Typeid)
            .HasColumnName("typeid")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Retype)
            .HasColumnName("retype")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        builder.Property(t => t.AutoUser)
            .HasColumnName("auto_user")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Level)
            .HasColumnName("level")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.ShopPermission)
            .IsRequired()
            .HasColumnName("shop_ permission")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'4'");

        builder.Property(t => t.OwinshopPermission)
            .IsRequired()
            .HasColumnName("owinshop_permission")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'4'");

        builder.Property(t => t.Facebookid)
            .HasColumnName("facebookid")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.Gooleid)
            .HasColumnName("gooleid")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.Every)
            .HasColumnName("every")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Consumption)
            .HasColumnName("consumption")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member";
    }

    public readonly struct Columns
    {
        public const string Uid = "uid";
        public const string Username = "username";
        public const string Email = "email";
        public const string Mobile = "mobile";
        public const string Password = "password";
        public const string UserIp = "user_ip";
        public const string Img = "img";
        public const string Qianming = "qianming";
        public const string Groupid = "groupid";
        public const string Addgroup = "addgroup";
        public const string Money = "money";
        public const string Emailcode = "emailcode";
        public const string Mobilecode = "mobilecode";
        public const string Othercode = "othercode";
        public const string Passcode = "passcode";
        public const string RegKey = "reg_key";
        public const string Score = "score";
        public const string Jingyan = "jingyan";
        public const string Yaoqing1 = "yaoqing1";
        public const string Yaoqing1name = "yaoqing1name";
        public const string Yaoqing2 = "yaoqing2";
        public const string Yaoqing2name = "yaoqing2name";
        public const string Band = "band";
        public const string Time = "time";
        public const string Headimg = "headimg";
        public const string Wxid = "wxid";
        public const string Typeid = "typeid";
        public const string Retype = "retype";
        public const string AutoUser = "auto_user";
        public const string Level = "level";
        public const string ShopPermission = "shop_ permission";
        public const string OwinshopPermission = "owinshop_permission";
        public const string Facebookid = "facebookid";
        public const string Gooleid = "gooleid";
        public const string Every = "every";
        public const string Consumption = "consumption";
    }
    #endregion
}
