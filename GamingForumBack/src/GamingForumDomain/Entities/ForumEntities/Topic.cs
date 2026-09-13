

using GamingForumDomain.Entities.Commons;
using GamingForumDomain.Entities.Identity;
using GamingForumDomain.Enums;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class Topic : BaseEntity
    {
        public Guid ForumId { get; set; }
        public Forum Forum { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public AppUser Author { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;      // "en-yaxsi-10-oyun-2026"
        public string Content { get; set; } = null!;   // markdown saxla, HTML yox
        public TopicType Type { get; set; } = TopicType.Discussion;

        public bool IsPinned { get; set; }
        public bool IsLocked { get; set; }
        public Guid? AcceptedAnswerCommentId { get; set; }  // Type == Question üçün

        // sayğaclar
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public int Score { get; set; }                 // Up - Down
        public double HotRank { get; set; }            // sıralama üçün, indekslənir

        public DateTimeOffset LastActivityAt { get; set; }
        public Guid? LastCommentAuthorId { get; set; }

        public ICollection<Comment> Comments { get; set; } = [];
        public ICollection<TopicTag> Tags { get; set; } = [];
        public ICollection<TopicVote> Votes { get; set; } = [];
        public Poll? Poll { get; set; }
    }
}
