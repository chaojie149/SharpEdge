using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoCardPwdMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoCardPwd>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoCardPwd> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_card_pwd");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int unsigned")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Pwd)
            .IsRequired()
            .HasColumnName("pwd")
            .HasColumnType("varchar(32)")
            .HasMaxLength(32);

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_card_pwd";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string Pwd = "pwd";
    }
    #endregion
}
