namespace FoodFood.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } 
        public string Salt { get; set; }
        public Personalia? Personalia { get; set; }
        public ICollection<Favorite> Favorite { get; set; } = new List<Favorite>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
