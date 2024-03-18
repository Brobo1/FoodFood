namespace FoodFood.Controller.ControllerModels
{
    public class CreateFavorite
    {
        public int ResturantId { get; set; }
        public int UserId { get; set; }
        public bool IsFavorite { get; set; }
    }
}
