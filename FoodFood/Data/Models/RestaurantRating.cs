namespace FoodFood.Data.Models
{
    public class RestaurantRating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int RatingId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Rating? Rating { get; set; }
        
        public ICollection<Favorite>? Favorite { get; set; }
    }
}
