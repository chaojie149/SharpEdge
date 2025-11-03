using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoShoplistCopyMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoShoplistCopy>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoShoplistCopy> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_shoplist_copy");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Sid)
            .IsRequired()
            .HasColumnName("sid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Cateid)
            .HasColumnName("cateid")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Brandid)
            .HasColumnName("brandid")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Language)
            .IsRequired()
            .HasColumnName("language")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.TitleStyle)
            .HasColumnName("title_style")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Title2)
            .HasColumnName("title2")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Keywords)
            .HasColumnName("keywords")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Money)
            .HasColumnName("money")
            .HasColumnType("bigint")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Yunjiage)
            .HasColumnName("yunjiage")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Zongrenshu)
            .HasColumnName("zongrenshu")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Canyurenshu)
            .HasColumnName("canyurenshu")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Shenyurenshu)
            .HasColumnName("shenyurenshu")
            .HasColumnType("int unsigned");

        builder.Property(t => t.DefRenshu)
            .HasColumnName("def_renshu")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Qishu)
            .HasColumnName("qishu")
            .HasColumnType("smallint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Maxqishu)
            .HasColumnName("maxqishu")
            .HasColumnType("smallint unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Thumb)
            .HasColumnName("thumb")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Picarr)
            .HasColumnName("picarr")
            .HasColumnType("text");

        builder.Property(t => t.Content)
            .HasColumnName("content")
            .HasColumnType("mediumtext");

        builder.Property(t => t.CodesTable)
            .HasColumnName("codes_table")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.XsjxTime)
            .HasColumnName("xsjx_time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Pos)
            .HasColumnName("pos")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Renqi)
            .HasColumnName("renqi")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Order)
            .HasColumnName("order")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.QUid)
            .HasColumnName("q_uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.QUser)
            .IsRequired()
            .HasColumnName("q_user")
            .HasColumnType("text");

        builder.Property(t => t.QUserCode)
            .HasColumnName("q_user_code")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.QContent)
            .HasColumnName("q_content")
            .HasColumnType("mediumtext");

        builder.Property(t => t.QCounttime)
            .HasColumnName("q_counttime")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.QEndTime)
            .HasColumnName("q_end_time")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.QShowtime)
            .HasColumnName("q_showtime")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        builder.Property(t => t.Zhiding)
            .IsRequired()
            .HasColumnName("zhiding")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Goucount)
            .HasColumnName("goucount")
            .HasColumnType("int");

        builder.Property(t => t.Buycount)
            .HasColumnName("buycount")
            .HasColumnType("int");

        builder.Property(t => t.Ispk)
            .HasColumnName("ispk")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.QExternalCode)
            .HasColumnName("q_external_code")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.QExternalContent)
            .HasColumnName("q_external_content")
            .HasColumnType("char(255)")
            .HasMaxLength(255);

        builder.Property(t => t.QEndCounttime)
            .HasColumnName("q_end_counttime")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Ssc)
            .HasColumnName("ssc")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_shoplist_copy";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Sid = "sid";
        public const string Cateid = "cateid";
        public const string Brandid = "brandid";
        public const string Language = "language";
        public const string Title = "title";
        public const string TitleStyle = "title_style";
        public const string Title2 = "title2";
        public const string Keywords = "keywords";
        public const string Description = "description";
        public const string Money = "money";
        public const string Yunjiage = "yunjiage";
        public const string Zongrenshu = "zongrenshu";
        public const string Canyurenshu = "canyurenshu";
        public const string Shenyurenshu = "shenyurenshu";
        public const string DefRenshu = "def_renshu";
        public const string Qishu = "qishu";
        public const string Maxqishu = "maxqishu";
        public const string Thumb = "thumb";
        public const string Picarr = "picarr";
        public const string Content = "content";
        public const string CodesTable = "codes_table";
        public const string XsjxTime = "xsjx_time";
        public const string Pos = "pos";
        public const string Renqi = "renqi";
        public const string Time = "time";
        public const string Order = "order";
        public const string QUid = "q_uid";
        public const string QUser = "q_user";
        public const string QUserCode = "q_user_code";
        public const string QContent = "q_content";
        public const string QCounttime = "q_counttime";
        public const string QEndTime = "q_end_time";
        public const string QShowtime = "q_showtime";
        public const string Zhiding = "zhiding";
        public const string Goucount = "goucount";
        public const string Buycount = "buycount";
        public const string Ispk = "ispk";
        public const string QExternalCode = "q_external_code";
        public const string QExternalContent = "q_external_content";
        public const string QEndCounttime = "q_end_counttime";
        public const string Ssc = "ssc";
    }
    #endregion
}
