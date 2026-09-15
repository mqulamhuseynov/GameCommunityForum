
using Microsoft.AspNetCore.Identity;


namespace GamingForumDomain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        // Forumda gorunen ad. null olanda service UserName-e fallback etsin.
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }

        // denormalized sayqaclar
        public int Reputation { get; set; }
        public int TopicCount { get; set; }
        public int CommentCount { get; set; }

        public DateTimeOffset? LastSeenAt { get; set; }
        public bool IsBanned { get; set; }
        public DateTimeOffset? BannedUntil { get; set; }
    }
}
