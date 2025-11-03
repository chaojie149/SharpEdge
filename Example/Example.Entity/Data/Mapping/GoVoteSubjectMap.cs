using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Example.Entity.Data.Mapping;

public partial class GoVoteSubjectMap
    : IEntityTypeConfiguration<Example.Entity.Data.Entities.GoVoteSubject>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Example.Entity.Data.Entities.GoVoteSubject> builder)
    {
        #region Generated Configure
        // table
        builder.ToTable("go_vote_subject");

        // key
        builder.HasNoKey();

        // properties
        builder.Property(t => t.VoteId)
            .IsRequired()
            .HasColumnName("vote_id")
            .HasColumnType("int");

        builder.Property(t => t.VoteTitle)
            .HasColumnName("vote_title")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(t => t.VoteStarttime)
            .HasColumnName("vote_starttime")
            .HasColumnType("int");

        builder.Property(t => t.VoteEndtime)
            .HasColumnName("vote_endtime")
            .HasColumnType("int");

        builder.Property(t => t.VoteSendtime)
            .HasColumnName("vote_sendtime")
            .HasColumnType("int");

        builder.Property(t => t.VoteDescription)
            .HasColumnName("vote_description")
            .HasColumnType("text");

        builder.Property(t => t.VoteAllowview)
            .HasColumnName("vote_allowview")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.VoteAllowguest)
            .HasColumnName("vote_allowguest")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.VoteInterval)
            .HasColumnName("vote_interval")
            .HasColumnType("int")
            .HasDefaultValueSql("'0'");

        builder.Property(t => t.VoteEnabled)
            .HasColumnName("vote_enabled")
            .HasColumnType("tinyint(1)");

        builder.Property(t => t.VoteNumber)
            .HasColumnName("vote_number")
            .HasColumnType("int");

        // relationships
        #endregion
    }

    #region Generated Constants
    public readonly struct Table
    {
        public const string Schema = "";
        public const string Name = "go_vote_subject";
    }

    public readonly struct Columns
    {
        public const string VoteId = "vote_id";
        public const string VoteTitle = "vote_title";
        public const string VoteStarttime = "vote_starttime";
        public const string VoteEndtime = "vote_endtime";
        public const string VoteSendtime = "vote_sendtime";
        public const string VoteDescription = "vote_description";
        public const string VoteAllowview = "vote_allowview";
        public const string VoteAllowguest = "vote_allowguest";
        public const string VoteInterval = "vote_interval";
        public const string VoteEnabled = "vote_enabled";
        public const string VoteNumber = "vote_number";
    }
    #endregion
}
