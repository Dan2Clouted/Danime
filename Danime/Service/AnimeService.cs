using Danime.Models;
using Newtonsoft.Json;

namespace Danime.Service
{
    public class AnimeService
    {
        private readonly HttpClient _httpClient;

        public AnimeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Search for anime based on a query
        public async Task<AnimeData.Root> SearchAnime(string query)
        {
            try
            {
                Console.WriteLine($"Searching for anime: {query}");

                var response = await _httpClient.GetStringAsync($"https://api.jikan.moe/v4/anime?q={query}");
                Console.WriteLine($"API Response: {response}");

                var searchResult = JsonConvert.DeserializeObject<AnimeData.Root>(response);
                return searchResult ?? new AnimeData.Root();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching anime: {ex.Message}");
                return new AnimeData.Root(); // Return an empty object if an error occurs
            }
        }

        // Fetch top 10 animes
        public async Task<List<AnimeData.Datum>> GetTopAnimesAsync()
        {
            try
            {
                string url = "https://api.jikan.moe/v4/top/anime?limit=10";
                var response = await _httpClient.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<AnimeData.Root>(response);

                return data?.data ?? new List<AnimeData.Datum>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching top animes: {ex.Message}");
                return new List<AnimeData.Datum>(); // Return an empty list in case of error
            }
        }

        // Fetch Airing Anime
        public async Task<List<AnimeData.Datum>> GetAiringAnimeAsync()
        {
            string url = "https://api.jikan.moe/v4/anime?status=airing";
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<AnimeData.Root>(response);

            return data?.data ?? new List<AnimeData.Datum>();

        } 

        public async Task<List<AnimeData.Datum>> GetTrendingEpisodesAsync()
        {
            string url = "https://api.jikan.moe/v4/watch/episodes/popular";
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<AnimeData.Root>(response);
            return data?.data ?? new List<AnimeData.Datum>();
        }

    }
}
