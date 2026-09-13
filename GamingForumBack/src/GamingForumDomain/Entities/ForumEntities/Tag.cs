using GamingForumDomain.Entities.Commons;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = null!;      // "Top 10"
        public string Slug { get; set; } = null!;      // "top-10", unique
        public string? Description { get; set; }
        public int UsageCount { get; set; }            // denormalized
        public bool IsActive { get; set; } = true;

        public ICollection<TopicTag> Topics { get; set; } = [];
    }
}
