using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWechatConfigMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWechatConfig>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWechatConfig> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_wechat_config");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(t => t.Token)
            .IsRequired()
            .HasColumnName("token")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Appid)
            .IsRequired()
            .HasColumnName("appid")
            .HasColumnType("char(18)")
            .HasMaxLength(18);

        builder.Property(t => t.Appsecret)
            .IsRequired()
            .HasColumnName("appsecret")
            .HasColumnType("char(32)")
            .HasMaxLength(32);

        builder.Property(t => t.AccessToken)
            .IsRequired()
            .HasColumnName("access_token")
            .HasColumnType("text");

        builder.Property(t => t.Dateline)
            .IsRequired()
            .HasColumnName("dateline")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Menu)
            .IsRequired()
            .HasColumnName("menu")
            .HasColumnType("text");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_wechat_config";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Token = "token";
        public const string Appid = "appid";
        public const string Appsecret = "appsecret";
        public const string AccessToken = "access_token";
        public const string Dateline = "dateline";
        public const string Menu = "menu";
    }
    #endregion
}
