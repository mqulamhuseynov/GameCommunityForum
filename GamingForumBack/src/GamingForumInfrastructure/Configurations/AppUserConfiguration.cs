using GamingForumDomain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    // Identity cedveli (AspNetUsers) uzerine elave sahelerin konfiqurasiyasi.
    // ToTable cagirilmir -- adi Identity-nin ozu teyin edir.
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.LastName).HasMaxLength(100);
            builder.Property(u => u.DisplayName).HasMaxLength(50);
            builder.Property(u => u.AvatarUrl).HasMaxLength(500);
            builder.Property(u => u.Bio).HasMaxLength(1000);

            builder.HasIndex(u => u.DisplayName);
            builder.HasIndex(u => u.Reputation).IsDescending();   // leaderboard
        }
    }
}
