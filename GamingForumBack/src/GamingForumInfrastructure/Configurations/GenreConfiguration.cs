using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name).IsRequired().HasMaxLength(80);
            builder.Property(g => g.Slug).IsRequired().HasMaxLength(100);

            builder.HasIndex(g => g.Slug).IsUnique();

            builder.HasQueryFilter(g => !g.IsDeleted);
        }
    }
}
