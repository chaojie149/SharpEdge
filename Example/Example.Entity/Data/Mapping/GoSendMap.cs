using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoSendMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoSend>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoSend> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_send");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Uid)
            .HasColumnName("uid")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Gid)
            .HasColumnName("gid")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Username)
            .HasColumnName("username")
            .HasColumnType("char(50)")
            .HasMaxLength(50)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Shoptitle)
            .HasColumnName("shoptitle")
            .HasColumnType("char(120)")
            .HasMaxLength(120)
            .HasDefaultValueSql("''");

        builder.Property(t => t.SendType)
            .HasColumnName("send_type")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.SendTime)
            .HasColumnName("send_time")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_send";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Gid = "gid";
        public const string Username = "username";
        public const string Shoptitle = "shoptitle";
        public const string SendType = "send_type";
        public const string SendTime = "send_time";
    }
    #endregion
}
