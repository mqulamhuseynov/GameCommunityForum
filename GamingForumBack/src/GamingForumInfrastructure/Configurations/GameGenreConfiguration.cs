using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.ToTable("GameGenres");

            // Composite PK: eyni oyuna eyni janr iki defe elave oluna bilmez
            builder.HasKey(gg => new { gg.GameId, gg.GenreId });

            builder.HasOne(gg => gg.Game)
                   .WithMany(g => g.Genres)
                   .HasForeignKey(gg => gg.GameId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gg => gg.Genre)
                   .WithMany(g => g.Games)
                   .HasForeignKey(gg => gg.GenreId)
                   .OnDelete(DeleteBehavior.Cascade);

            // "Bu janrdaki butun oyunlar" query-si ucun
            builder.HasIndex(gg => gg.GenreId);

            builder.HasQueryFilter(gg => !gg.Game.IsDeleted && !gg.Genre.IsDeleted);
        }
    }
}
