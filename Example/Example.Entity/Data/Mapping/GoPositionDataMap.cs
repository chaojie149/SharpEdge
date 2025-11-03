using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoPositionDataMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoPositionData>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoPositionData> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_position_data");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.ConId)
            .IsRequired()
            .HasColumnName("con_id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.ModId)
            .IsRequired()
            .HasColumnName("mod_id")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.ModName)
            .IsRequired()
            .HasColumnName("mod_name")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.PosId)
            .IsRequired()
            .HasColumnName("pos_id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.PosData)
            .IsRequired()
            .HasColumnName("pos_data")
            .HasColumnType("mediumtext");

        builder.Property(t => t.PosOrder)
            .IsRequired()
            .HasColumnName("pos_order")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'1'");

        builder.Property(t => t.PosTime)
            .IsRequired()
            .HasColumnName("pos_time")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_position_data";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string ConId = "con_id";
        public const string ModId = "mod_id";
        public const string ModName = "mod_name";
        public const string PosId = "pos_id";
        public const string PosData = "pos_data";
        public const string PosOrder = "pos_order";
        public const string PosTime = "pos_time";
    }
    #endregion
}
