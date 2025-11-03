using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoShopcollectMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoShopcollect>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoShopcollect> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_shopcollect");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Shopid)
            .HasColumnName("shopid")
            .HasColumnType("int");

        builder.Property(t => t.Uid)
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("char(100)")
            .HasMaxLength(100);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_shopcollect";
    }

    public readonly struct Columns
    {
        public const string Shopid = "shopid";
        public const string Uid = "uid";
        public const string Time = "time";
    }
    #endregion
}
