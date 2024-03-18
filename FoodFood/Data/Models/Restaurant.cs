namespace FoodFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OpeningTime { get; set; } = DateTime.Now;
        public DateTime ClosingTime { get; set; } = DateTime.Now;
        public bool IsOpen { get; set; }
        public string Image { get; set; } = string.Empty;
        public ICollection<MealRestaurant> MealRestaurants { get; set; } = new List<MealRestaurant>();
        public ICollection<Favorite> Favorite { get; set; } = new List<Favorite>();
        public ICollection<RestaurantRating> RestaurantRatings { get; set; } = new List<RestaurantRating>();
    }

}
