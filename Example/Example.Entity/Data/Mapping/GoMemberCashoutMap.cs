using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberCashoutMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberCashout>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberCashout> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_cashout");

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
            .HasColumnType("int unsigned");

        builder.Property(t => t.Username)
            .IsRequired()
            .HasColumnName("username")
            .HasColumnType("varchar(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Bankname)
            .IsRequired()
            .HasColumnName("bankname")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Branch)
            .IsRequired()
            .HasColumnName("branch")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Money)
            .IsRequired()
            .HasColumnName("money")
            .HasColumnType("decimal(16,0)");

        builder.Property(t => t.Time)
            .IsRequired()
            .HasColumnName("time")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Banknumber)
            .IsRequired()
            .HasColumnName("banknumber")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Linkphone)
            .IsRequired()
            .HasColumnName("linkphone")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.Auditstatus)
            .IsRequired()
            .HasColumnName("auditstatus")
            .HasColumnType("tinyint");

        builder.Property(t => t.Procefees)
            .IsRequired()
            .HasColumnName("procefees")
            .HasColumnType("decimal(8,2)");

        builder.Property(t => t.Reviewtime)
            .IsRequired()
            .HasColumnName("reviewtime")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Code)
            .IsRequired()
            .HasColumnName("code")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Oid)
            .IsRequired()
            .HasColumnName("oid")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_cashout";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string Username = "username";
        public const string Bankname = "bankname";
        public const string Branch = "branch";
        public const string Money = "money";
        public const string Time = "time";
        public const string Banknumber = "banknumber";
        public const string Linkphone = "linkphone";
        public const string Auditstatus = "auditstatus";
        public const string Procefees = "procefees";
        public const string Reviewtime = "reviewtime";
        public const string Code = "code";
        public const string Oid = "oid";
    }
    #endregion
}
