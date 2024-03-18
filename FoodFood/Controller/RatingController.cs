using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly FoodFoodContext _db;

        public RatingController(FoodFoodContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRating(int id)
        {
            var rating = await _db.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpGet]
        public async Task<ActionResult> GetRatings()
        {
            var ratings = await _db.Rating.ToListAsync();
            return Ok(ratings);
        }
        [HttpGet("restaurant/{id}")]
        public async Task<ActionResult> GetRatingsByRestaurant(int id)
        {
            var ratings = await _db.Rating.Include(r => r.RestaurantRating).Where(r => r.RestaurantRating.Any(rr => rr.RestaurantId == id)).ToListAsync();
            return Ok(ratings);
        }
        [HttpPost]
        public async Task<ActionResult> CreateRating(CreateRating rating)
        {
            Rating newRating = new ()
            {
                Review = rating.Review,
                UserId = rating.UserId,
                Stars = rating.Stars

            };
            _db.Rating.Add(newRating);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRating), new { id = newRating.Id}, newRating);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRating(int id, CreateRating rating)
        {
            var ratingToUpdate = await _db.Rating.FindAsync(id);
            if (ratingToUpdate == null)
            {
                return NotFound();
            }
            ratingToUpdate.Review = rating.Review;
            ratingToUpdate.UserId = rating.UserId;
            ratingToUpdate.Stars = rating.Stars;
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRating(int id)
        {
            var rating = await _db.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            _db.Rating.Remove(rating);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
