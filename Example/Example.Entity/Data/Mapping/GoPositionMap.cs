using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoPositionMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoPosition>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoPosition> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_position");

        // key
        builder.HasKey(t => t.PosId);

        // properties
        builder.Property(t => t.PosId)
            .IsRequired()
            .HasColumnName("pos_id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.PosModel)
            .IsRequired()
            .HasColumnName("pos_model")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.PosName)
            .IsRequired()
            .HasColumnName("pos_name")
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(t => t.PosNum)
            .IsRequired()
            .HasColumnName("pos_num")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.PosMaxnum)
            .IsRequired()
            .HasColumnName("pos_maxnum")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.PosThisNum)
            .IsRequired()
            .HasColumnName("pos_this_num")
            .HasColumnType("tinyint unsigned");

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
        public const string Name = "go_position";
    }

    public readonly struct Columns
    {
        public const string PosId = "pos_id";
        public const string PosModel = "pos_model";
        public const string PosName = "pos_name";
        public const string PosNum = "pos_num";
        public const string PosMaxnum = "pos_maxnum";
        public const string PosThisNum = "pos_this_num";
        public const string PosTime = "pos_time";
    }
    #endregion
}
