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
        public async Task<AnimeData.Root> SearchAnime(string query)
        {
            try
            {
                Console.WriteLine($"Searching for anime: {query}"); 

                var response = await _httpClient.GetStringAsync($"https://api.jikan.moe/v4/anime?q={query}");
                Console.WriteLine($"API Response: {response}"); 

                var searchResult = JsonConvert.DeserializeObject<AnimeData.Root>(response);

                return searchResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching anime: {ex.Message}");
                return new AnimeData.Root(); // Return an empty list if an error occurs
            }
        }




    }
}
