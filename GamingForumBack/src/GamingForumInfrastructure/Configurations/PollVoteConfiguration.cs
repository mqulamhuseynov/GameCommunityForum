using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class PollVoteConfiguration : IEntityTypeConfiguration<PollVote>
    {
        public void Configure(EntityTypeBuilder<PollVote> builder)
        {
            builder.ToTable("PollVotes");

            // Composite PK: eyni varianta ikinci defe ses vermek mumkun deyil
            builder.HasKey(v => new { v.PollOptionId, v.UserId });

            builder.HasOne(v => v.PollOption)
                   .WithMany(o => o.Votes)
                   .HasForeignKey(v => v.PollOptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // PollId denormalized saxlanilir ki, "bu user bu poll-da ses veribmi?"
            // sualina PollOptions-a JOIN etmeden cavab verek.
            builder.HasOne(v => v.Poll)
                   .WithMany(p => p.Votes)
                   .HasForeignKey(v => v.PollId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Tek secimli poll-da "yalniz bir variant" qaydasini yoxlamaq ucun
            builder.HasIndex(v => new { v.PollId, v.UserId });
            builder.HasIndex(v => v.UserId);

            builder.HasQueryFilter(v => !v.Poll.IsDeleted);
        }
    }
}
