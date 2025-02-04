using Danime.Models;
using Danime.Service;
using Microsoft.AspNetCore.Mvc;

namespace Danime.Controllers
{
    public class AnimeController : Controller
    {
        private readonly AnimeService _animeService;

        public AnimeController(AnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View();
            }

            AnimeData.Root searchResults = (await _animeService.SearchAnime(search)); 
            return View(searchResults);
        }


    }
}
