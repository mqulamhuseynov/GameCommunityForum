using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Polls");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Question).IsRequired().HasMaxLength(300);

            // 1:1 -> WithOne. Topic silinse poll da gedir.
            builder.HasOne(p => p.Topic)
                   .WithOne(t => t.Poll)
                   .HasForeignKey<Poll>(p => p.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.TopicId).IsUnique();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
