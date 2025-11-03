using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoVoteOptionMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoVoteOption>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoVoteOption> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_vote_option");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.OptionId)
            .IsRequired()
            .HasColumnName("option_id")
            .HasColumnType("int");

        builder.Property(t => t.VoteId)
            .HasColumnName("vote_id")
            .HasColumnType("int");

        builder.Property(t => t.OptionTitle)
            .HasColumnName("option_title")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.OptionNumber)
            .HasColumnName("option_number")
            .HasColumnType("int unsigned")
            .HasDefaultValueSql("'0'");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_vote_option";
    }

    public readonly struct Columns
    {
        public const string OptionId = "option_id";
        public const string VoteId = "vote_id";
        public const string OptionTitle = "option_title";
        public const string OptionNumber = "option_number";
    }
    #endregion
}
