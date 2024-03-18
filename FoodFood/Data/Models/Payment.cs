namespace FoodFood.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public int CardNumber {  get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardHolderName {  get; set; } = string.Empty;
        public Personalia? Personalia { get; set; }
    }
}
