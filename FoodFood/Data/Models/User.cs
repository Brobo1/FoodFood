namespace FoodFood.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public Personalia? Personalia { get; set; }
        public ICollection<Favorite>? Favorite { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
