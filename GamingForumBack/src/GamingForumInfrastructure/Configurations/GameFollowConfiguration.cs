using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class GameFollowConfiguration : IEntityTypeConfiguration<GameFollow>
    {
        public void Configure(EntityTypeBuilder<GameFollow> builder)
        {
            builder.ToTable("GameFollows");

            builder.HasKey(gf => new { gf.GameId, gf.UserId });

            builder.HasOne(gf => gf.Game)
                   .WithMany(g => g.Followers)
                   .HasForeignKey(gf => gf.GameId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gf => gf.User)
                   .WithMany()
                   .HasForeignKey(gf => gf.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // "Menim izlediyim oyunlar", en son izlenen yuxarida
            builder.HasIndex(gf => new { gf.UserId, gf.CreatedAt }).IsDescending(false, true);

            builder.HasQueryFilter(gf => !gf.Game.IsDeleted);
        }
    }
}
