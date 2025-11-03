using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoWeixinBonusMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoWeixinBonus>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoWeixinBonus> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_weixin_bonus");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.TypeId)
            .IsRequired()
            .HasColumnName("type_id")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_weixin_bonus";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string TypeId = "type_id";
    }
    #endregion
}
