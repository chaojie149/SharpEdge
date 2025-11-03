using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoGoogleMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoGoogle>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoGoogle> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_google");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Secret)
            .IsRequired()
            .HasColumnName("secret")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_google";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Secret = "secret";
    }
    #endregion
}
