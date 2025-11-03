using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCategoryMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCategory>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCategory> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_category");

        // key
        builder.HasKey(t => t.Cateid);

        // properties
        builder.Property(t => t.Cateid)
            .IsRequired()
            .HasColumnName("cateid")
            .HasColumnType("smallint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Language)
            .HasColumnName("language")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Parentid)
            .HasColumnName("parentid")
            .HasColumnType("smallint");

        builder.Property(t => t.Channel)
            .IsRequired()
            .HasColumnName("channel")
            .HasColumnType("tinyint");

        builder.Property(t => t.Model)
            .HasColumnName("model")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Catdir)
            .HasColumnName("catdir")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.PicUrl)
            .IsRequired()
            .HasColumnName("pic_url")
            .HasColumnType("char(200)")
            .HasMaxLength(200)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Url)
            .HasColumnName("url")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Info)
            .HasColumnName("info")
            .HasColumnType("text");

        builder.Property(t => t.Order)
            .HasColumnName("order")
            .HasColumnType("smallint unsigned")
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_category";
    }

    public readonly struct Columns
    {
        public const string Cateid = "cateid";
        public const string Language = "language";
        public const string Parentid = "parentid";
        public const string Channel = "channel";
        public const string Model = "model";
        public const string Name = "name";
        public const string Catdir = "catdir";
        public const string PicUrl = "pic_url";
        public const string Url = "url";
        public const string Info = "info";
        public const string Order = "order";
    }
    #endregion
}
