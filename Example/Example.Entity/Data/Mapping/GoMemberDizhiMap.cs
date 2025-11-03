using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberDizhiMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberDizhi>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberDizhi> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_dizhi");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.Guo)
            .IsRequired()
            .HasColumnName("guo")
            .HasColumnType("int");

        builder.Property(t => t.Sheng)
            .HasColumnName("sheng")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Shi)
            .HasColumnName("shi")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Xian)
            .HasColumnName("xian")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Jiedao)
            .HasColumnName("jiedao")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Youbian)
            .HasColumnName("youbian")
            .HasColumnType("mediumint");

        builder.Property(t => t.Shouhuoren)
            .HasColumnName("shouhuoren")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Mobile)
            .HasColumnName("mobile")
            .HasColumnType("char(11)")
            .HasMaxLength(11);

        builder.Property(t => t.Tell)
            .HasColumnName("tell")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Default)
            .HasColumnName("default")
            .HasColumnType("char(1)")
            .HasMaxLength(1)
            .HasDefaultValueSql("'N'");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Qq)
            .IsRequired()
            .HasColumnName("qq")
            .HasColumnType("char(20)")
            .HasMaxLength(20)
            .HasDefaultValueSql("''");

        builder.Property(t => t.Shifoufahuo)
            .IsRequired()
            .HasColumnName("shifoufahuo")
            .HasColumnType("tinyint unsigned");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_dizhi";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Guo = "guo";
        public const string Sheng = "sheng";
        public const string Shi = "shi";
        public const string Xian = "xian";
        public const string Jiedao = "jiedao";
        public const string Youbian = "youbian";
        public const string Shouhuoren = "shouhuoren";
        public const string Mobile = "mobile";
        public const string Tell = "tell";
        public const string Default = "default";
        public const string Time = "time";
        public const string Qq = "qq";
        public const string Shifoufahuo = "shifoufahuo";
    }
    #endregion
}
