using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoShaidanMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoShaidan>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoShaidan> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_shaidan");

        // key
        builder.HasKey(t => t.SdId);

        // properties
        builder.Property(t => t.SdId)
            .IsRequired()
            .HasColumnName("sd_id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.SdUserid)
            .HasColumnName("sd_userid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.SdShopid)
            .HasColumnName("sd_shopid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.SdQishu)
            .HasColumnName("sd_qishu")
            .HasColumnType("int");

        builder.Property(t => t.SdIp)
            .HasColumnName("sd_ip")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.SdTitle)
            .HasColumnName("sd_title")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        builder.Property(t => t.SdThumbs)
            .HasColumnName("sd_thumbs")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        builder.Property(t => t.SdContent)
            .HasColumnName("sd_content")
            .HasColumnType("text");

        builder.Property(t => t.SdPhotolist)
            .HasColumnName("sd_photolist")
            .HasColumnType("text");

        builder.Property(t => t.SdZhan)
            .HasColumnName("sd_zhan")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.SdPing)
            .HasColumnName("sd_ping")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.SdTime)
            .HasColumnName("sd_time")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_shaidan";
    }

    public readonly struct Columns
    {
        public const string SdId = "sd_id";
        public const string SdUserid = "sd_userid";
        public const string SdShopid = "sd_shopid";
        public const string SdQishu = "sd_qishu";
        public const string SdIp = "sd_ip";
        public const string SdTitle = "sd_title";
        public const string SdThumbs = "sd_thumbs";
        public const string SdContent = "sd_content";
        public const string SdPhotolist = "sd_photolist";
        public const string SdZhan = "sd_zhan";
        public const string SdPing = "sd_ping";
        public const string SdTime = "sd_time";
    }
    #endregion
}
