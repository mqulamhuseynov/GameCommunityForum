using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name).IsRequired().HasMaxLength(200);
            builder.Property(g => g.Slug).IsRequired().HasMaxLength(220);
            builder.Property(g => g.Description).HasMaxLength(4000);
            builder.Property(g => g.CoverImageUrl).HasMaxLength(500);
            builder.Property(g => g.BannerImageUrl).HasMaxLength(500);
            builder.Property(g => g.Developer).HasMaxLength(200);
            builder.Property(g => g.Publisher).HasMaxLength(200);

            builder.HasIndex(g => g.Slug).IsUnique();
            builder.HasIndex(g => g.Name);
            builder.HasIndex(g => g.SteamAppId);
            builder.HasIndex(g => g.IgdbId);

            builder.HasQueryFilter(g => !g.IsDeleted);
        }
    }
}
