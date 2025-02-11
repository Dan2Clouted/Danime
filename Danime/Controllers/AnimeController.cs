using Danime.Models;
using Danime.Service;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        public async Task<IActionResult> Details(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return RedirectToAction("Search");
            }

            var searchResults = await _animeService.SearchAnime(search); // Call API with search term

            if (searchResults == null || !searchResults.data.Any())
            {
                return NotFound();
            }

            var animeDetails = searchResults.data.FirstOrDefault(); // Get first matching anime

            return View(animeDetails);
        }


    }
}
