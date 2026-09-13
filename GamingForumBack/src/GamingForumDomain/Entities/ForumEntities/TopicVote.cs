using GamingForumDomain.Entities.Identity;
using GamingForumDomain.Enums;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class TopicVote
    {
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;
        public VoteValue Value { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
