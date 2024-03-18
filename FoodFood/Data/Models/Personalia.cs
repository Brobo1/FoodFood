namespace FoodFood.Data.Models
{
    public class Personalia
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Address { get; set; } = string.Empty;
        public ICollection<Payment>? Payments { get; set; }
        public User? User { get; set; }
    }
}
