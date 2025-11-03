using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCjlistMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCjlist>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCjlist> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_cjlist");

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

        builder.Property(t => t.Wxid)
            .IsRequired()
            .HasColumnName("wxid")
            .HasColumnType("char(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Codeid)
            .IsRequired()
            .HasColumnName("codeid")
            .HasColumnType("char(20)")
            .HasMaxLength(20)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Come)
            .IsRequired()
            .HasColumnName("come")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Sum)
            .IsRequired()
            .HasColumnName("sum")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_cjlist";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Wxid = "wxid";
        public const string Time = "time";
        public const string Codeid = "codeid";
        public const string Come = "come";
        public const string Sum = "sum";
    }
    #endregion
}
