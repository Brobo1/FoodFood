namespace FoodFood.Controller.ControllerModels
{
    public class CreateRating
    {
        public string Review { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int Stars { get; set; }
        public int RestaurantId { get; set; }
    }
}
