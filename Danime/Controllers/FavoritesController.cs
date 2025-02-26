using Danime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Danime.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly DanimeContext _context;

        public FavoritesController(DanimeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int animeId, string title, string imageUrl, string type)
        {
            var userId = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
 
            var existingFavorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.AnimeId == animeId && f.UserId == userId && f.Type == type);

            if (existingFavorite == null)
            {
                var favorite = new Favorites 
                {
                    AnimeId = animeId,
                    Title = title,
                    ImageUrl = imageUrl,
                    Type = type,  
                    UserId = userId
                };

                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("FavoritesList");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("FavoritesList");
        }

        public async Task<IActionResult> FavoritesList()
        {
            var userId = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var favorites = await _context.Favorites
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return View(favorites);
        }
    }
}
