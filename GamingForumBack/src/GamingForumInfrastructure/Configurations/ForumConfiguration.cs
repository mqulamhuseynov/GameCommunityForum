using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class ForumConfiguration : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("Forums");
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name).IsRequired().HasMaxLength(150);
            builder.Property(f => f.Slug).IsRequired().HasMaxLength(170);
            builder.Property(f => f.Description).HasMaxLength(1000);
            builder.Property(f => f.ForumType).IsRequired();

            builder.HasOne(f => f.Category)
                   .WithMany(c => c.Forums)
                   .HasForeignKey(f => f.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);   // dolu kateqoriya tesaduffen silinmesin

            builder.HasOne(f => f.Game)
                   .WithMany(g => g.Forums)
                   .HasForeignKey(f => f.GameId)
                   .OnDelete(DeleteBehavior.Restrict);

            // LastTopicId qesden FK deyil: Forum -> Topic -> Forum dovresi yaranmasin.
            // Sadece son topic-i tez tapmaq ucun saxlanilan Id-dir.

            // Eyni kateqoriya daxilinde slug tekrarlanmasin
            builder.HasIndex(f => new { f.CategoryId, f.Slug }).IsUnique();
            builder.HasIndex(f => f.GameId);
            builder.HasIndex(f => f.ForumType);
            builder.HasIndex(f => f.DisplayOrder);

            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
