using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberGroupMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberGroup>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberGroup> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_group");

        // key
        builder.HasKey(t => t.Groupid);

        // properties
        builder.Property(t => t.Groupid)
            .IsRequired()
            .HasColumnName("groupid")
            .HasColumnType("tinyint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("char(15)")
            .HasMaxLength(15);

        builder.Property(t => t.JingyanStart)
            .IsRequired()
            .HasColumnName("jingyan_start")
            .HasColumnType("int unsigned");

        builder.Property(t => t.JingyanEnd)
            .IsRequired()
            .HasColumnName("jingyan_end")
            .HasColumnType("int");

        builder.Property(t => t.Icon)
            .HasColumnName("icon")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_group";
    }

    public readonly struct Columns
    {
        public const string Groupid = "groupid";
        public const string Name = "name";
        public const string JingyanStart = "jingyan_start";
        public const string JingyanEnd = "jingyan_end";
        public const string Icon = "icon";
        public const string Type = "type";
    }
    #endregion
}
