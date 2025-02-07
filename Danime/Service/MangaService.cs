using Danime.Models;

namespace Danime.Service
{
    public class MangaService
    {
        private readonly HttpClient _httpClient;

        public MangaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MangaData.Datum>> SearchManga(string query)
        {
            var response = await _httpClient.GetAsync($"https://api.jikan.moe/v4/manga?q={query}&page=1");
            response.EnsureSuccessStatusCode();

            // Deserialize the response into the Root class
            var mangaData = await response.Content.ReadFromJsonAsync<MangaData.Root>();

            return mangaData.data;  // Returning the list of manga results
        }
    }
}
