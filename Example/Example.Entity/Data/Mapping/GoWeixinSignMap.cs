using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinSignMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinSign>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinSign> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_sign");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.InputTime)
            .IsRequired()
            .HasColumnName("input_time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Typeid)
            .IsRequired()
            .HasColumnName("typeid")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_sign";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Status = "status";
        public const string InputTime = "input_time";
        public const string Typeid = "typeid";
    }
    #endregion
}
