namespace FoodFood.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int cardNumber {  get; set; }
        public DateTime expirationDate { get; set; }
        public string cardHolderName {  get; set; }
        public Personalia? Personalia { get; set; }
    }
}
