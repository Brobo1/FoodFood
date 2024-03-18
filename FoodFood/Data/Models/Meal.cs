namespace FoodFood.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string MealImage { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Allergens { get; set; } = string.Empty;
        public ICollection<MealRestaurant> MealRestaurants { get; set; } = new List<MealRestaurant>();
        public ICollection<MealOrder> MealOrders { get; set; } = new List<MealOrder>();
        
    }
}
