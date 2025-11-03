using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoShaidanHueifuMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoShaidanHueifu>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoShaidanHueifu> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_shaidan_hueifu");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.SdhfId)
            .IsRequired()
            .HasColumnName("sdhf_id")
            .HasColumnType("int");

        builder.Property(t => t.SdhfUserid)
            .HasColumnName("sdhf_userid")
            .HasColumnType("int");

        builder.Property(t => t.SdhfContent)
            .HasColumnName("sdhf_content")
            .HasColumnType("text");

        builder.Property(t => t.SdhfTime)
            .HasColumnName("sdhf_time")
            .HasColumnType("int");

        builder.Property(t => t.SdhfUsername)
            .HasColumnName("sdhf_username")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.SdhfImg)
            .HasColumnName("sdhf_img")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_shaidan_hueifu";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string SdhfId = "sdhf_id";
        public const string SdhfUserid = "sdhf_userid";
        public const string SdhfContent = "sdhf_content";
        public const string SdhfTime = "sdhf_time";
        public const string SdhfUsername = "sdhf_username";
        public const string SdhfImg = "sdhf_img";
    }
    #endregion
}
