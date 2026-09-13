

using GamingForumDomain.Entities.Commons;

namespace GamingForumDomain.Entities.ForumEntities
{
        public class Category : BaseEntity
        {
            public string Name { get; set; } = null!;
            public string Slug { get; set; } = null!;      // unique
            public string? Description { get; set; }
            public string? IconUrl { get; set; }
            public string? ColorHex { get; set; }
            public int DisplayOrder { get; set; }
            public bool IsActive { get; set; } = true;

            public ICollection<Forum> Forums { get; set; } = [];
        }

}
