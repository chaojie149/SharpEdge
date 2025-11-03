using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinPointMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinPoint>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinPoint> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_point");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.PointId)
            .IsRequired()
            .HasColumnName("point_id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.PointName)
            .IsRequired()
            .HasColumnName("point_name")
            .HasColumnType("varchar(64)")
            .HasMaxLength(64)
            .HasDefaultValueSql("''");

        builder.Property(t => t.PointValue)
            .IsRequired()
            .HasColumnName("point_value")
            .HasColumnType("int unsigned");

        builder.Property(t => t.PointNum)
            .IsRequired()
            .HasColumnName("point_num")
            .HasColumnType("int");

        builder.Property(t => t.Autoload)
            .IsRequired()
            .HasColumnName("autoload")
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .HasDefaultValueSql("'yes'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_point";
    }

    public readonly struct Columns
    {
        public const string PointId = "point_id";
        public const string PointName = "point_name";
        public const string PointValue = "point_value";
        public const string PointNum = "point_num";
        public const string Autoload = "autoload";
    }
    #endregion
}
