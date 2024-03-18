using Microsoft.EntityFrameworkCore;

namespace FoodFood.Data
{
    public class FoodFoodContext : DbContext
    {
        public FoodFoodContext(DbContextOptions<FoodFoodContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Payment> Payment { get; set; }



    }
}
