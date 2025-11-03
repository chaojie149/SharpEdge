using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoSignInMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoSignIn>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoSignIn> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_sign_in");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Uid)
            .IsRequired()
            .HasColumnName("uid")
            .HasColumnType("int");

        builder.Property(t => t.SignDate)
            .IsRequired()
            .HasColumnName("sign_date")
            .HasColumnType("date");

        builder.Property(t => t.Points)
            .IsRequired()
            .HasColumnName("points")
            .HasColumnType("int")
            .HasDefaultValueSql("'100'");

        builder.Property(t => t.CreateTime)
            .IsRequired()
            .HasColumnName("create_time")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_sign_in";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Uid = "uid";
        public const string SignDate = "sign_date";
        public const string Points = "points";
        public const string CreateTime = "create_time";
    }
    #endregion
}
