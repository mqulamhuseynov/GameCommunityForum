using GamingForumDomain.Entities.Commons;
using GamingForumDomain.Entities.ForumEntities;
using GamingForumDomain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GamingForumInfrastructure.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<GameGenre> GameGenres => Set<GameGenre>();
        public DbSet<GameFollow> GameFollows => Set<GameFollow>();
        public DbSet<Forum> Forums => Set<Forum>();
        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TopicTag> TopicTags => Set<TopicTag>();
        public DbSet<TopicVote> TopicVotes => Set<TopicVote>();
        public DbSet<CommentVote> CommentVotes => Set<CommentVote>();
        public DbSet<Poll> Polls => Set<Poll>();
        public DbSet<PollOption> PollOptions => Set<PollOption>();
        public DbSet<PollVote> PollVotes => Set<PollVote>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditAndSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ApplyAuditAndSoftDelete();
            return base.SaveChanges();
        }

        // CreatedAt / UpdatedAt-i elle doldurmaga ehtiyac yoxdur -- burda olur.
        // Remove() cagirilsa da real DELETE getmir, sadece IsDeleted = true olur.
        private void ApplyAuditAndSoftDelete()
        {
            var now = DateTimeOffset.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        entry.Entity.UpdatedAt = now;
                        break;

                    case EntityState.Modified:
                        // CreatedAt tesadufen uzerine yazilmasin
                        entry.Property(e => e.CreatedAt).IsModified = false;
                        entry.Entity.UpdatedAt = now;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = now;
                        entry.Entity.UpdatedAt = now;
                        entry.Property(e => e.CreatedAt).IsModified = false;
                        break;
                }
            }
        }
    }
}
