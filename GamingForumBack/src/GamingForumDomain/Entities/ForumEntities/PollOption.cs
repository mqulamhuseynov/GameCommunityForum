using GamingForumDomain.Entities.Commons;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class PollOption : BaseEntity
    {
        public Guid PollId { get; set; }
        public Poll Poll { get; set; } = null!;

        public string Text { get; set; } = null!;
        public int DisplayOrder { get; set; }

        // denormalized: bu varianta nece ses verilib.
        // Faiz hesablamaq ucun: VoteCount * 100.0 / Poll.TotalVoterCount
        public int VoteCount { get; set; }

        public ICollection<PollVote> Votes { get; set; } = [];
    }
}
