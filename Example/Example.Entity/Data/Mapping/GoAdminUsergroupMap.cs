using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoAdminUsergroupMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoAdminUsergroup>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoAdminUsergroup> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_admin_usergroup");

        // key
        builder.HasKey(t => t.Mid);

        // properties
        builder.Property(t => t.Mid)
            .IsRequired()
            .HasColumnName("mid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Permission)
            .IsRequired()
            .HasColumnName("permission")
            .HasColumnType("char(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("'ALL'");

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("char(50)")
            .HasMaxLength(50);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_admin_usergroup";
    }

    public readonly struct Columns
    {
        public const string Mid = "mid";
        public const string Name = "name";
        public const string Permission = "permission";
        public const string Time = "time";
    }
    #endregion
}
