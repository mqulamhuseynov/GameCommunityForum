using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class PollOptionConfiguration : IEntityTypeConfiguration<PollOption>
    {
        public void Configure(EntityTypeBuilder<PollOption> builder)
        {
            builder.ToTable("PollOptions");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Text).IsRequired().HasMaxLength(200);

            builder.HasOne(o => o.Poll)
                   .WithMany(p => p.Options)
                   .HasForeignKey(o => o.PollId)
                   .OnDelete(DeleteBehavior.Cascade);

            // "Bu poll-un variantlari, siraya gore"
            builder.HasIndex(o => new { o.PollId, o.DisplayOrder });

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}
