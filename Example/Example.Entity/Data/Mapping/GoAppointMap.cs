using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoAppointMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoAppoint>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoAppoint> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_appoint");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Shopid)
            .IsRequired()
            .HasColumnName("shopid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Userid)
            .IsRequired()
            .HasColumnName("userid")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasColumnType("int unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_appoint";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Shopid = "shopid";
        public const string Userid = "userid";
        public const string Time = "time";
        public const string Status = "status";
    }
    #endregion
}
