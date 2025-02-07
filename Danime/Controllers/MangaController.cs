using Danime.Models;
using Danime.Service;
using Microsoft.AspNetCore.Mvc;

public class MangaController : Controller
{
    private readonly MangaService _mangaService;

    public MangaController(MangaService mangaService)
    {
        _mangaService = mangaService;
    }

    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new List<MangaData.Datum>());
        }

        var mangaResults = await _mangaService.SearchManga(query);

        // Handle empty results here (optional)
        if (mangaResults == null || !mangaResults.Any())
        {
            ViewBag.Message = "No manga found for your search.";
        }

        return View(mangaResults);
    }


}
