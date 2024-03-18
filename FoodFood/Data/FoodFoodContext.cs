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
        public DbSet<Models.MealOrder> MealOrder { get; set; }
        public DbSet<Models.MealRestaurant> MealResturant { get; set; }
        public DbSet<Models.Order> Order { get; set; }
        public DbSet<Models.Payment> Payment { get; set; }
        public DbSet<Models.Personalia> Personalia { get; set; }
        public DbSet<Models.Rating> Rating { get; set; }
        public DbSet<Models.Restaurant> Restaurants { get; set; }
        public DbSet<Models.RestaurantRating> RestaurantRatings { get; set; }
        public DbSet<Models.User> User { get; set; }
    }
}
