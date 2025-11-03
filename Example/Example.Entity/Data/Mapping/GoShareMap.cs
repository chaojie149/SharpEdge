using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoShareMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoShare>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoShare> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_share");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_share";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Time = "time";
    }
    #endregion
}
