using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberMessageMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberMessage>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberMessage> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_message");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Type)
            .HasColumnName("type")
            .HasColumnType("tinyint(1)")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Sendid)
            .HasColumnName("sendid")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Sendname)
            .HasColumnName("sendname")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Content)
            .HasColumnName("content")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_message";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Type = "type";
        public const string Sendid = "sendid";
        public const string Sendname = "sendname";
        public const string Content = "content";
        public const string Time = "time";
    }
    #endregion
}
