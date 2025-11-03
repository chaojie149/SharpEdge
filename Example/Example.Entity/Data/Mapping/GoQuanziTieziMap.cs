using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoQuanziTieziMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoQuanziTiezi>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoQuanziTiezi> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_quanzi_tiezi");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Qzid)
            .HasColumnName("qzid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Hueiyuan)
            .HasColumnName("hueiyuan")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Neirong)
            .HasColumnName("neirong")
            .HasColumnType("text");

        builder.Property(t => t.Hueifu)
            .IsRequired()
            .HasColumnName("hueifu")
            .HasColumnType("smallint unsigned");

        builder.Property(t => t.Dianji)
            .IsRequired()
            .HasColumnName("dianji")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Zhiding)
            .HasColumnName("zhiding")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        builder.Property(t => t.Jinghua)
            .HasColumnName("jinghua")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        builder.Property(t => t.Zuihou)
            .HasColumnName("zuihou")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_quanzi_tiezi";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Qzid = "qzid";
        public const string Hueiyuan = "hueiyuan";
        public const string Title = "title";
        public const string Neirong = "neirong";
        public const string Hueifu = "hueifu";
        public const string Dianji = "dianji";
        public const string Zhiding = "zhiding";
        public const string Jinghua = "jinghua";
        public const string Zuihou = "zuihou";
        public const string Time = "time";
    }
    #endregion
}
