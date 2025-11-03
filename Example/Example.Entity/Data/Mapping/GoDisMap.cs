using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoDisMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoDis>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoDis> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_dis");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.FirstClass)
            .IsRequired()
            .HasColumnName("first_class")
            .HasColumnType("decimal(10,2)");

        builder.Property(t => t.TwoClass)
            .IsRequired()
            .HasColumnName("two_class")
            .HasColumnType("decimal(10,2)");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_dis";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string FirstClass = "first_class";
        public const string TwoClass = "two_class";
    }
    #endregion
}
