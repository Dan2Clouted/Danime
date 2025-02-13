using Danime.Models;
using Newtonsoft.Json;

namespace Danime.Service
{
    public class MangaService
    {
        private readonly HttpClient _httpClient;

        public MangaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MangaData.Datum> GetMangaById(int id)
        {
            var response = await _httpClient.GetAsync($"https://api.jikan.moe/v4/manga/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
            }

            var rootSingle = await response.Content.ReadFromJsonAsync<MangaData.RootSingle>();
            return rootSingle?.data;
        }



        public async Task<IEnumerable<MangaData.Datum>> SearchMangaByQuery(string query)
        {
            var response = await _httpClient.GetAsync($"https://api.jikan.moe/v4/manga?q={query}&page=1");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
            }
            
            var mangaData = await response.Content.ReadFromJsonAsync<MangaData.Root>();

            return mangaData?.data ?? new List<MangaData.Datum>();  // Return empty list if no data
        }

        public async Task<List<AnimeData.Datum>> GetTopMangaAsync()
        {
            try
            {
                string url = "https://api.jikan.moe/v4/top/manga?limit=10"; // Fetch Top 10 Manga
                var response = await _httpClient.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<AnimeData.Root>(response);

                return data?.data ?? new List<AnimeData.Datum>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching top manga: {ex.Message}");
                return new List<AnimeData.Datum>();
            }
        }

    }
}
