using FoodFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class ResturantRatingController : ControllerBase
    {
        private readonly FoodFoodContext _db;
        public ResturantRatingController(FoodFoodContext db)
        {
            _db = db;
        }
        [HttpGet("{id}")]
        public async  Task<ActionResult> Get(int id)
        {
            var ResturantRating = await _db.RestaurantRatings.FindAsync(id);
            return Ok(ResturantRating);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var ResturantRating = await _db.RestaurantRatings.ToListAsync();
            return Ok(ResturantRating);
        }
    }
}
