namespace FoodFood.Data.Models
{
    public class Restaurant_Rating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int RatingId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
