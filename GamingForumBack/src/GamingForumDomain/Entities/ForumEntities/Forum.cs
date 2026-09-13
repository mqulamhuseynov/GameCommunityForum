using GamingForumDomain.Entities.Commons;
using GamingForumDomain.Enums;


namespace GamingForumDomain.Entities.ForumEntities
{
    public class Forum : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ForumType ForumType { get; set; }
        public Guid? GameId { get; set; }              // ForumType == Game olanda dolur
        public Game? Game { get; set; }

        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }

        public bool IsLocked { get; set; }             // yeni topic açmaq olmaz
        public bool IsActive { get; set; } = true;

        // denormalized — forum siyahısında N+1 count query-ni öldürür
        public int TopicCount { get; set; }
        public int CommentCount { get; set; }
        public Guid? LastTopicId { get; set; }
        public DateTimeOffset? LastActivityAt { get; set; }

        public ICollection<Topic> Topics { get; set; } = [];
    }
}
