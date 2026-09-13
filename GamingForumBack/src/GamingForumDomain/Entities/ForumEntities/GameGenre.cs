namespace GamingForumDomain.Entities.ForumEntities
{
    // Many-to-many join: Game <-> Genre.
    public class GameGenre
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
