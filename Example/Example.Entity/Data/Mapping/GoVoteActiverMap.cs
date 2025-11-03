using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoVoteActiverMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoVoteActiver>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoVoteActiver> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_vote_activer");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(t => t.OptionId)
            .IsRequired()
            .HasColumnName("option_id")
            .HasColumnType("int");

        builder.Property(t => t.VoteId)
            .HasColumnName("vote_id")
            .HasColumnType("int");

        builder.Property(t => t.Userid)
            .HasColumnName("userid")
            .HasColumnType("int");

        builder.Property(t => t.Ip)
            .HasColumnName("ip")
            .HasColumnType("char(20)")
            .HasMaxLength(20);

        builder.Property(t => t.Subtime)
            .HasColumnName("subtime")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_vote_activer";
    }

    public readonly struct Columns
    {
        public const string Id = "id";
        public const string OptionId = "option_id";
        public const string VoteId = "vote_id";
        public const string Userid = "userid";
        public const string Ip = "ip";
        public const string Subtime = "subtime";
    }
    #endregion
}
