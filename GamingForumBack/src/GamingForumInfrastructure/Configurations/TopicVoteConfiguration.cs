using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class TopicVoteConfiguration : IEntityTypeConfiguration<TopicVote>
    {
        public void Configure(EntityTypeBuilder<TopicVote> builder)
        {
            builder.ToTable("TopicVotes");

            // Composite PK = bir istifadeci eyni topic-e iki defe vote vere bilmez.
            // Bu qayda DB seviyyesinde qorunur, kodda yoxlamaga ehtiyac yoxdur.
            builder.HasKey(v => new { v.TopicId, v.UserId });

            builder.Property(v => v.Value).IsRequired();

            builder.HasOne(v => v.Topic)
                   .WithMany(t => t.Votes)
                   .HasForeignKey(v => v.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.User)
                   .WithMany()
                   .HasForeignKey(v => v.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(v => v.UserId);   // "menim vote-larim"

            builder.HasQueryFilter(v => !v.Topic.IsDeleted);
        }
    }
}
