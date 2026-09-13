using GamingForumDomain.Entities.Commons;

namespace GamingForumDomain.Entities.ForumEntities
{
    // Bir Topic-in EN COX bir Poll-u olur (1:1).
    // Topic.Type == TopicType.Poll olanda yaradilir.
    public class Poll : BaseEntity
    {
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        public string Question { get; set; } = null!;

        // false => tek secim (radio),  true => coxlu secim (checkbox)
        public bool IsMultipleChoice { get; set; }

        // IsMultipleChoice == true olanda maksimum nece variant secile biler
        public int MaxSelections { get; set; } = 1;

        // Ses verenler neticeni yalniz ses verdikden sonra gore bilsin?
        public bool HideResultsUntilVoted { get; set; }

        public DateTimeOffset? ClosesAt { get; set; }
        public bool IsClosed { get; set; }

        // denormalized: nece FERQLI istifadeci ses verib
        public int TotalVoterCount { get; set; }

        public ICollection<PollOption> Options { get; set; } = [];
        public ICollection<PollVote> Votes { get; set; } = [];
    }
}
