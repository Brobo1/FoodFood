namespace FoodFood.Data.Models
{
    public class Favorites
    {
        public int Id { get; set; }
        public int ResturantId { get; set; }
        public int UserId { get; set; }
        public bool IsFavorite { get; set; }
        public ICollection<User>? User { get; set; }
    }
}
