using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoLogisticsMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoLogistics>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoLogistics> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_logistics");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.LogName)
            .IsRequired()
            .HasColumnName("log_name")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(t => t.CreateTime)
            .IsRequired()
            .HasColumnName("create_time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.UpdateTime)
            .IsRequired()
            .HasColumnName("update_time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.IsState)
            .IsRequired()
            .HasColumnName("is_state")
            .HasColumnType("tinyint unsigned")
            .HasDefaultValueSql("'1'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_logistics";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string LogName = "log_name";
        public const string CreateTime = "create_time";
        public const string UpdateTime = "update_time";
        public const string IsState = "is_state";
    }
    #endregion
}
