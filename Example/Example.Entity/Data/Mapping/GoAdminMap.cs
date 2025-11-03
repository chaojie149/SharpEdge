using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoAdminMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoAdmin>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoAdmin> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_admin");

        // key
        builder.HasKey(t => t.Uid);

        // properties
        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("tinyint unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Mid)
            .IsRequired()
            .HasColumnName("mid")
            .HasColumnType("tinyint unsigned");

        builder.Property(t => t.Username)
            .IsRequired()
            .HasColumnName("username")
            .HasColumnType("char(15)")
            .HasMaxLength(15);

        builder.Property(t => t.Userpass)
            .IsRequired()
            .HasColumnName("userpass")
            .HasColumnType("char(32)")
            .HasMaxLength(32);

        builder.Property(t => t.Useremail)
            .HasColumnName("useremail")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Addtime)
            .HasColumnName("addtime")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Logintime)
            .HasColumnName("logintime")
            .HasColumnType("int unsigned");

        builder.Property(t => t.Loginip)
            .HasColumnName("loginip")
            .HasColumnType("varchar(15)")
            .HasMaxLength(15);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_admin";
    }

    public readonly struct Columns
    {
        public const string Uid = "uid";
        public const string Mid = "mid";
        public const string Username = "username";
        public const string Userpass = "userpass";
        public const string Useremail = "useremail";
        public const string Addtime = "addtime";
        public const string Logintime = "logintime";
        public const string Loginip = "loginip";
    }
    #endregion
}
