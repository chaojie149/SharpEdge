using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMentsMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMents>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMents> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_ments");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("mediumint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Pid)
            .HasColumnName("pid")
            .HasColumnType("mediumint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Type)
            .HasColumnName("type")
            .HasColumnType("tinyint(1)")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.IsEnable)
            .HasColumnName("is_enable")
            .HasColumnType("tinyint(1)")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.M)
            .HasColumnName("m")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.C)
            .HasColumnName("c")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.A)
            .HasColumnName("a")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.D)
            .HasColumnName("d")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);

        builder.Property(t => t.Url)
            .HasColumnName("url")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);

        builder.Property(t => t.Desc)
            .HasColumnName("desc")
            .HasColumnType("varchar(140)")
            .HasMaxLength(140);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_ments";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Pid = "pid";
        public const string Type = "type";
        public const string IsEnable = "is_enable";
        public const string Name = "name";
        public const string M = "m";
        public const string C = "c";
        public const string A = "a";
        public const string D = "d";
        public const string Url = "url";
        public const string Desc = "desc";
    }
    #endregion
}
