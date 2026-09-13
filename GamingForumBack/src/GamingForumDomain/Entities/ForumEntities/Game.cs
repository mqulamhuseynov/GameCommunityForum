using GamingForumDomain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamingForumDomain.Entities.ForumEntities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;      // "counter-strike-2", unique
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? BannerImageUrl { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string? Developer { get; set; }
        public string? Publisher { get; set; }

        // xarici mənbədən metadata çəkmək üçün (IGDB / RAWG / Steam)
        public int? IgdbId { get; set; }
        public int? SteamAppId { get; set; }

        public int FollowerCount { get; set; }         // denormalized
        public bool IsActive { get; set; } = true;

        public ICollection<Forum> Forums { get; set; } = [];
        public ICollection<GameGenre> Genres { get; set; } = [];
        public ICollection<GameFollow> Followers { get; set; } = [];
    }
}
