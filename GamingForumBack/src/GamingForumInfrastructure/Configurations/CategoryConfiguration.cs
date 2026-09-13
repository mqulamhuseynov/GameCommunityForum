using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Slug).IsRequired().HasMaxLength(120);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.IconUrl).HasMaxLength(500);
            builder.Property(c => c.ColorHex).HasMaxLength(9);   // "#RRGGBBAA"

            builder.HasIndex(c => c.Slug).IsUnique();
            builder.HasIndex(c => c.DisplayOrder);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
