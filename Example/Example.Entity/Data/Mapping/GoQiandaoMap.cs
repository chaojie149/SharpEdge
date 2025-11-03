using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoQiandaoMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoQiandao>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoQiandao> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_qiandao");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Lianxu)
            .IsRequired()
            .HasColumnName("lianxu")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Sum)
            .IsRequired()
            .HasColumnName("sum")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_qiandao";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Lianxu = "lianxu";
        public const string Sum = "sum";
        public const string Time = "time";
        public const string Uid = "uid";
    }
    #endregion
}
