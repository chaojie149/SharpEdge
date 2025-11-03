using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoKefuMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoKefu>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoKefu> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_kefu");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("char(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Img)
            .HasColumnName("img")
            .HasColumnType("char(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("tinyint")
            .HasDefaultValueSql("'-1'");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_kefu";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Name = "name";
        public const string Img = "img";
        public const string Status = "status";
        public const string Time = "time";
    }
    #endregion
}
