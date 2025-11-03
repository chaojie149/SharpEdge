using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoRegMoneyMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoRegMoney>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoRegMoney> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_reg_money");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Money)
            .HasColumnName("money")
            .HasColumnType("decimal(12,2)");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_reg_money";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Money = "money";
    }
    #endregion
}
