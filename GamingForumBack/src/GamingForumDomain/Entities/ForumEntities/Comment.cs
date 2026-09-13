using GamingForumDomain.Entities.Commons;
using GamingForumDomain.Entities.Identity;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class Comment : BaseEntity
    {
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public AppUser Author { get; set; } = null!;

        public string Content { get; set; } = null!;

        // ---- YouTube stili iyerarxiya ----
        // null => əsas comment (1-ci səviyyə)
        // dolu => həmin əsas comment-in cavabı (2-ci səviyyə)
        // Dərinlik HEÇ VAXT 2-ni keçmir.
        public Guid? RootCommentId { get; set; }
        public Comment? RootComment { get; set; }

        // Sırf UI-da "@Ali" yazmaq üçün. İyerarxiyaya təsiri YOXDUR,
        // ona görə FK qoymuruq (ikinci self-reference cascade problemi yaradır).
        public Guid? ReplyToCommentId { get; set; }
        public Guid? ReplyToUserId { get; set; }

        public int ReplyCount { get; set; }                // yalnız root comment-də mənalıdır
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public int Score { get; set; }
        public bool IsEdited { get; set; }

        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
        public ICollection<CommentVote> Votes { get; set; } = new List<CommentVote>();
    }
}