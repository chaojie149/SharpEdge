using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoQuanziMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoQuanzi>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoQuanzi> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_quanzi");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("char(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Img)
            .HasColumnName("img")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Chengyuan)
            .HasColumnName("chengyuan")
            .HasColumnType("mediumint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Tiezi)
            .HasColumnName("tiezi")
            .HasColumnType("mediumint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Guanli)
            .IsRequired()
            .HasColumnName("guanli")
            .HasColumnType("mediumint unsigned");

        builder.Property(t => t.Jinhua)
            .HasColumnName("jinhua")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Jianjie)
            .HasColumnName("jianjie")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("'暂无介绍'");

        builder.Property(t => t.Gongao)
            .HasColumnName("gongao")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("'暂无'");

        builder.Property(t => t.Jiaru)
            .HasColumnName("jiaru")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'Y'");

        builder.Property(t => t.Glfatie)
            .HasColumnName("glfatie")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_quanzi";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Title = "title";
        public const string Img = "img";
        public const string Chengyuan = "chengyuan";
        public const string Tiezi = "tiezi";
        public const string Guanli = "guanli";
        public const string Jinhua = "jinhua";
        public const string Jianjie = "jianjie";
        public const string Gongao = "gongao";
        public const string Jiaru = "jiaru";
        public const string Glfatie = "glfatie";
        public const string Time = "time";
    }
    #endregion
}
