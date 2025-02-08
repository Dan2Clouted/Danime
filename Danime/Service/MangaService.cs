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
    }
}
