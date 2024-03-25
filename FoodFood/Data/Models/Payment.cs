namespace FoodFood.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string CardNumber {  get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public string CardHolderName {  get; set; } = string.Empty;
        public int PersonaliaId { get; set; }
        public Personalia? Personalia { get; set; }
    }
}
