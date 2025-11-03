using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoZpZjMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoZpZj>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoZpZj> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_zp_zj");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(t => t.Uid)
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Grade)
            .HasColumnName("Grade")
            .HasColumnType("int");

        builder.Property(t => t.Content)
            .IsRequired()
            .HasColumnName("content")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("int");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("int");

        builder.Property(t => t.Ren)
            .HasColumnName("ren")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Yqren)
            .IsRequired()
            .HasColumnName("yqren")
            .HasColumnType("int");

        builder.Property(t => t.State)
            .HasColumnName("state")
            .HasColumnType("int");

        builder.Property(t => t.Addrid)
            .HasColumnName("addrid")
            .HasColumnType("int");

        builder.Property(t => t.Kd)
            .IsRequired()
            .HasColumnName("kd")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Kdd)
            .IsRequired()
            .HasColumnName("kdd")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_zp_zj";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Grade = "Grade";
        public const string Content = "content";
        public const string Type = "type";
        public const string Time = "time";
        public const string Ren = "ren";
        public const string Yqren = "yqren";
        public const string State = "state";
        public const string Addrid = "addrid";
        public const string Kd = "kd";
        public const string Kdd = "kdd";
    }
    #endregion
}
