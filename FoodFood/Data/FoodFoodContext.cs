using FoodFood.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Data
{
    public class FoodFoodContext : DbContext
    {
        public FoodFoodContext(DbContextOptions<FoodFoodContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Favorite> Favorite { get; set; }
        public DbSet<Models.Meal> Meal { get; set; }
        public DbSet<Models.Meal_Restaurant> Meal_Resturant { get; set; }
        public DbSet<Models.Payment> Payment { get; set; }



    }
}
