using GamingForumDomain.Entities.Identity;

namespace GamingForumDomain.Entities.ForumEntities
{
    // Composite PK (PollOptionId, UserId): bir istifadeci eyni varianta
    // iki defe ses vere bilmez. Tek secimli poll-da "yalniz bir variant"
    // qaydasi service layer-de yoxlanilir (PollId + UserId indeksi ile).
    public class PollVote
    {
        public Guid PollOptionId { get; set; }
        public PollOption PollOption { get; set; } = null!;

        public Guid PollId { get; set; }
        public Poll Poll { get; set; } = null!;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
