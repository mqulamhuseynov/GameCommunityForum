using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Slug).IsRequired().HasMaxLength(220);
            builder.Property(t => t.Content).IsRequired().HasMaxLength(40000);
            builder.Property(t => t.Type).IsRequired();

            builder.HasOne(t => t.Forum)
                   .WithMany(f => f.Topics)
                   .HasForeignKey(t => t.ForumId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Author)
                   .WithMany()
                   .HasForeignKey(t => t.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);   // user silinse topic-leri qalsin

            // AcceptedAnswerCommentId ve LastCommentAuthorId qesden FK deyil:
            // Topic -> Comment -> Topic dovresi yaranmasin.

            // "Hot / Top" siralamasi
            builder.HasIndex(t => new { t.ForumId, t.HotRank }).IsDescending(false, true);
            builder.HasIndex(t => new { t.ForumId, t.Score }).IsDescending(false, true);

            // "New" siralamasi
            builder.HasIndex(t => new { t.ForumId, t.CreatedAt }).IsDescending(false, true);

            // "Active" siralamasi + pin-lenmisler yuxarida
            builder.HasIndex(t => new { t.ForumId, t.IsPinned, t.LastActivityAt })
                   .IsDescending(false, true, true);

            builder.HasIndex(t => new { t.AuthorId, t.CreatedAt }).IsDescending(false, true);
            builder.HasIndex(t => t.Slug);

            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
