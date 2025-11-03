using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinKeywordsMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinKeywords>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinKeywords> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_keywords");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Keyword)
            .IsRequired()
            .HasColumnName("keyword")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Contents)
            .IsRequired()
            .HasColumnName("contents")
            .HasColumnType("text");

        builder.Property(t => t.Pic)
            .IsRequired()
            .HasColumnName("pic")
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

        builder.Property(t => t.PicTit)
            .IsRequired()
            .HasColumnName("pic_tit")
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

        builder.Property(t => t.Desc)
            .IsRequired()
            .HasColumnName("desc")
            .HasColumnType("text");

        builder.Property(t => t.PicUrl)
            .IsRequired()
            .HasColumnName("pic_url")
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

        builder.Property(t => t.Count)
            .IsRequired()
            .HasColumnName("count")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_keywords";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Name = "name";
        public const string Keyword = "keyword";
        public const string Type = "type";
        public const string Contents = "contents";
        public const string Pic = "pic";
        public const string PicTit = "pic_tit";
        public const string Desc = "desc";
        public const string PicUrl = "pic_url";
        public const string Count = "count";
        public const string Status = "status";
    }
    #endregion
}
