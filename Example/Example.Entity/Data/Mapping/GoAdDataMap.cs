using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoAdDataMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoAdData>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoAdData> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_ad_data");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Aid)
            .IsRequired()
            .HasColumnName("aid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Type)
            .HasColumnName("type")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Content)
            .HasColumnName("content")
            .HasColumnType("text");

        builder.Property(t => t.Checked)
            .HasColumnName("checked")
            .HasColumnType("tinyint(1)")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Addtime)
            .IsRequired()
            .HasColumnName("addtime")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Endtime)
            .IsRequired()
            .HasColumnName("endtime")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_ad_data";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Aid = "aid";
        public const string Title = "title";
        public const string Type = "type";
        public const string Content = "content";
        public const string Checked = "checked";
        public const string Addtime = "addtime";
        public const string Endtime = "endtime";
    }
    #endregion
}
