using GamingForumDomain.Entities.Identity;

namespace GamingForumDomain.Entities.ForumEntities
{
    // Istifadeci oyunu izleyir -> oz feed-inde o oyunun topic-lerini gorur.
    // Composite PK (GameId, UserId): eyni oyunu iki defe izlemek mumkun deyil.
    public class GameFollow
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
