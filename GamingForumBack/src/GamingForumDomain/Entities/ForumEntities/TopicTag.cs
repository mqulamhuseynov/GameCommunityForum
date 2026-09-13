namespace GamingForumDomain.Entities.ForumEntities
{
    // Many-to-many join: Topic <-> Tag.
    // Composite PK (TopicId, TagId) oldugu ucun BaseEntity-den gelmir.
    public class TopicTag
    {
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        public Guid TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
