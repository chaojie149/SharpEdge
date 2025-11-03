using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinPointRecordMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinPointRecord>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinPointRecord> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_point_record");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.PrId)
            .IsRequired()
            .HasColumnName("pr_id")
            .HasColumnType("int");

        builder.Property(t => t.Wxid)
            .IsRequired()
            .HasColumnName("wxid")
            .HasColumnType("char(28)")
            .HasMaxLength(28);

        builder.Property(t => t.PointName)
            .IsRequired()
            .HasColumnName("point_name")
            .HasColumnType("varchar(64)")
            .HasMaxLength(64);

        builder.Property(t => t.Num)
            .IsRequired()
            .HasColumnName("num")
            .HasColumnType("int");

        builder.Property(t => t.Lasttime)
            .IsRequired()
            .HasColumnName("lasttime")
            .HasColumnType("int");

        builder.Property(t => t.Datelinie)
            .IsRequired()
            .HasColumnName("datelinie")
            .HasColumnType("int");

        builder.Property(t => t.Total)
            .IsRequired()
            .HasColumnName("total")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_point_record";
    }

    public readonly struct Columns
    {
        public const string PrId = "pr_id";
        public const string Wxid = "wxid";
        public const string PointName = "point_name";
        public const string Num = "num";
        public const string Lasttime = "lasttime";
        public const string Datelinie = "datelinie";
        public const string Total = "total";
    }
    #endregion
}
