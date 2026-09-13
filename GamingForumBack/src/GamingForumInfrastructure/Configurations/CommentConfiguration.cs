using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Content).IsRequired().HasMaxLength(20000);

            builder.HasOne(c => c.Topic)
                   .WithMany(t => t.Comments)
                   .HasForeignKey(c => c.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Author)
                   .WithMany()
                   .HasForeignKey(c => c.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Self-reference. MUTLEQ Restrict olmalidir -- Cascade olsa
            // EF "multiple cascade paths" xetasi verecek.
            builder.HasOne(c => c.RootComment)
                   .WithMany(c => c.Replies)
                   .HasForeignKey(c => c.RootCommentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ReplyToCommentId / ReplyToUserId qesden FK deyil:
            // onlar sirf UI-da "@istifadeci" gostermek ucundur.

            // "Topic-in esas comment-leri, en cox beyenilen yuxarida"
            builder.HasIndex(c => new { c.TopicId, c.RootCommentId, c.Score })
                   .IsDescending(false, false, true);

            // "Bu comment-in cavablarini goster" (kohneden yeniye)
            builder.HasIndex(c => new { c.RootCommentId, c.CreatedAt });

            builder.HasIndex(c => new { c.AuthorId, c.CreatedAt }).IsDescending(false, true);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
