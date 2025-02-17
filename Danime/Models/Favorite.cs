namespace Danime.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int AnimeId { get; set; } // ID from Jikan API
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; } // Anime or Manga
        public string UserId { get; set; } // User who favorited it
    }
}
