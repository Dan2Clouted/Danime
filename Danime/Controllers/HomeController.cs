using System.Diagnostics;
using Danime.Models;
using Danime.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Danime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnimeService _animeService;
        private readonly MangaService _mangaService;

        // ✅ FIXED: Ensure only ONE constructor exists
        public HomeController(ILogger<HomeController> logger, AnimeService animeService, MangaService mangaService)
        {
            _logger = logger;
            _animeService = animeService;
            _mangaService = mangaService;
        }

        public async Task<IActionResult> Index()
        {
            var topAnime = await _animeService.GetTopAnimesAsync(); // Fetch Top Anime
            var topManga = await _mangaService.GetTopMangaAsync(); // Fetch Top Manga
            var airingAnime = await _animeService.GetAiringAnimeAsync(); // Fetch Recently Aired Episodes
            

            return View((topAnime, topManga, airingAnime));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Manga()
        {
            return View();
        }

        public IActionResult TermsofUse()
        {
            return View();
        }

        public IActionResult Accessibility()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
