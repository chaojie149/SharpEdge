using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCurrencyMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCurrency>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCurrency> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_currency");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Title)
            .HasColumnName("title")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Code)
            .IsRequired()
            .HasColumnName("code")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.SymbolLeft)
            .IsRequired()
            .HasColumnName("symbol_left")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.SymbolRight)
            .IsRequired()
            .HasColumnName("symbol_right")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("enum('0','1')")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.Unit)
            .IsRequired()
            .HasColumnName("unit")
            .HasColumnType("char(10)")
            .HasMaxLength(10);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_currency";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Title = "title";
        public const string Code = "code";
        public const string SymbolLeft = "symbol_left";
        public const string SymbolRight = "symbol_right";
        public const string Status = "status";
        public const string Unit = "unit";
    }
    #endregion
}
