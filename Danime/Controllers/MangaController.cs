using Danime.Models;
using Danime.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MangaController : Controller
{
    private readonly MangaService _mangaService;

    public MangaController(MangaService mangaService)
    {
        _mangaService = mangaService;
    }

    [Authorize]
    // Searching manga by query
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new List<MangaData.Datum>());
        }

        try
        {
            var mangaResults = await _mangaService.SearchMangaByQuery(query);
            ViewData["query"] = query;  // Pass the query to the view
            return View(mangaResults);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error: {ex.Message}";
            return View(new List<MangaData.Datum>());
        }
    }


    // Fetching manga by ID
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var manga = await _mangaService.GetMangaById(id);
            if (manga == null)
            {
                ViewBag.ErrorMessage = "Manga not found.";
                return View("Error");
            }
            return View(manga);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Error: {ex.Message}";
            return View("Error");
        }
    }

}
