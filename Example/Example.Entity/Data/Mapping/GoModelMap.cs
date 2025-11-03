using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoModelMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoModel>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoModel> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_model");

        // key
        builder.HasKey(t => t.Modelid);

        // properties
        builder.Property(t => t.Modelid)
            .IsRequired()
            .HasColumnName("modelid")
            .HasColumnType("smallint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        builder.Property(t => t.Table)
            .IsRequired()
            .HasColumnName("table")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_model";
    }

    public readonly struct Columns
    {
        public const string Modelid = "modelid";
        public const string Name = "name";
        public const string Table = "table";
    }
    #endregion
}
