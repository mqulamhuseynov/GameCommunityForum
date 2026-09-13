using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Slug).IsRequired().HasMaxLength(60);
            builder.Property(t => t.Description).HasMaxLength(300);

            builder.HasIndex(t => t.Slug).IsUnique();
            builder.HasIndex(t => t.UsageCount).IsDescending();   // "populyar tag-lar"

            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
