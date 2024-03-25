using System.ComponentModel.DataAnnotations;

namespace FoodFood.Controller.ControllerModels
{
    public class PaymentModel
    {
        [Required]
        public string?  Type { get; set; }
        [Required]
        public string  CardNumber { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string? CardHolderName { get; set; }
    }
}
