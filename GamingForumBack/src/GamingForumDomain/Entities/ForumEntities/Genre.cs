using GamingForumDomain.Entities.Commons;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = null!;      // "FPS", "MMORPG", "Battle Royale"
        public string Slug { get; set; } = null!;      // "fps", unique
        public bool IsActive { get; set; } = true;

        public ICollection<GameGenre> Games { get; set; } = [];
    }
}
