using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly FoodFoodContext _db;

        public FavoriteController(FoodFoodContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFavorite(int id)
        {
            var favorite = await _db.Favorite.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            return Ok(favorite);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetFavoritesByUser(int id)
        {
            var favorites = await _db.Favorite.Where(f => f.UserId == id).ToListAsync();
            return Ok(favorites);
        }
        [HttpGet]
        public async Task<ActionResult> GetFavorites()
        {
            var favorites = await _db.Favorite.ToListAsync();
            return Ok(favorites);
        }
        [HttpPost]
        public async Task<ActionResult> CreateFavorite(CreateFavorite favorite)
        {
            Favorite newFavorite = new ()
            {
                UserId = favorite.UserId,
                ResturantId = favorite.ResturantId¨,
                IsFavorite = favorite.IsFavorite
            };
            _db.Favorite.Add(newFavorite);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFavorite), new { id = newFavorite.Id}, newFavorite);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFavorite(int id)
        {
            var favorite = await _db.Favorite.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            _db.Favorite.Remove(favorite);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFavorite(int id, CreateFavorite favorite)
        {
            var favoriteToUpdate = await _db.Favorite.FindAsync(id);
            if (favoriteToUpdate == null)
            {
                return NotFound();
            }
            favoriteToUpdate.UserId = favorite.UserId;
            favoriteToUpdate.ResturantId = favorite.ResturantId;
            favoriteToUpdate.IsFavorite = favorite.IsFavorite;
            await _db.SaveChangesAsync();
            return NoContent();
        }
        


    }
}
