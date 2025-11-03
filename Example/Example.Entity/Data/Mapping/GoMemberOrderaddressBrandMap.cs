using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoMemberOrderaddressBrandMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoMemberOrderaddressBrand>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoMemberOrderaddressBrand> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_member_orderaddress_brand");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.OrderCode)
            .HasColumnName("order_code")
            .HasColumnType("int");

        builder.Property(t => t.AddressId)
            .HasColumnName("address_id")
            .HasColumnType("int");

        builder.Property(t => t.Address)
            .HasColumnName("address")
            .HasColumnType("varchar(1024)")
            .HasMaxLength(1024);

        builder.Property(t => t.Time)
            .HasColumnName("time")
            .HasColumnType("text");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_member_orderaddress_brand";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string OrderCode = "order_code";
        public const string AddressId = "address_id";
        public const string Address = "address";
        public const string Time = "time";
    }
    #endregion
}
