using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class CommentVoteConfiguration : IEntityTypeConfiguration<CommentVote>
    {
        public void Configure(EntityTypeBuilder<CommentVote> builder)
        {
            builder.ToTable("CommentVotes");

            builder.HasKey(v => new { v.CommentId, v.UserId });

            builder.Property(v => v.Value).IsRequired();

            builder.HasOne(v => v.Comment)
                   .WithMany(c => c.Votes)
                   .HasForeignKey(v => v.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.User)
                   .WithMany()
                   .HasForeignKey(v => v.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(v => v.UserId);

            builder.HasQueryFilter(v => !v.Comment.IsDeleted);
        }
    }
}
