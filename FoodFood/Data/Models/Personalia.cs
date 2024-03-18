namespace FoodFood.Data.Models
{
    public class Personalia
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public ICollection<Payment>? payments { get; }
        public User? User { get; set; }
    }
}
