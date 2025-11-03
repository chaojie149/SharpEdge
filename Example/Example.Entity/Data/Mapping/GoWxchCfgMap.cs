using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWxchCfgMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWxchCfg>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWxchCfg> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_wxch_cfg");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.CfgId)
            .IsRequired()
            .HasColumnName("cfg_id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.CfgName)
            .IsRequired()
            .HasColumnName("cfg_name")
            .HasColumnType("varchar(64)")
            .HasMaxLength(64)
            .HasDefaultValueSql("''");

        builder.Property(t => t.CfgValue)
            .IsRequired()
            .HasColumnName("cfg_value")
            .HasColumnType("text");

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
        public const string Name = "go_wxch_cfg";
    }

    public readonly struct Columns
    {
        public const string CfgId = "cfg_id";
        public const string CfgName = "cfg_name";
        public const string CfgValue = "cfg_value";
        public const string Autoload = "autoload";
    }
    #endregion
}
