using FoodFood.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace FoodFood.Data {
	public class FoodFoodContext : DbContext {
		public FoodFoodContext(DbContextOptions<FoodFoodContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Favorite>         Favorite          { get; set; }
		public DbSet<Meal>             Meal              { get; set; }
		public DbSet<MealOrder>        MealOrder         { get; set; }
		public DbSet<Order>            Order             { get; set; }
		public DbSet<Payment>          Payment           { get; set; }
		public DbSet<Personalia>       Personalia        { get; set; }
		public DbSet<Rating>           Rating            { get; set; }
		public DbSet<Restaurant>       Restaurants       { get; set; }
		public DbSet<RestaurantRating> RestaurantRatings { get; set; }
		public DbSet<User>             User              { get; set; }
	}
	
	
	
	
}