using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberZpMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberZp>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberZp> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_zp");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("tinyint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Money)
            .IsRequired()
            .HasColumnName("money")
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Img)
            .IsRequired()
            .HasColumnName("img")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Grade)
            .IsRequired()
            .HasColumnName("Grade")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Probability)
            .IsRequired()
            .HasColumnName("probability")
            .HasColumnType("tinyint");

        builder.Property(t => t.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("tinyint");

        builder.Property(t => t.Ren)
            .HasColumnName("ren")
            .HasColumnType("tinyint");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_zp";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Name = "name";
        public const string Money = "money";
        public const string Img = "img";
        public const string Grade = "Grade";
        public const string Probability = "probability";
        public const string Type = "type";
        public const string Ren = "ren";
    }
    #endregion
}
