namespace FoodFood.Data.Models
{
    public class MealRestaurant
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int RestaurantId { get; set; }
        public Meal? Meal { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
