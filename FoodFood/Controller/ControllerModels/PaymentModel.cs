using System.ComponentModel.DataAnnotations;

namespace FoodFood.Controller.ControllerModels
{
    public class PaymentModel
    {
        [Required]
        public string?  Type { get; set; }
        [Required]
        public int  cardNumber { get; set; }
        [Required]
        public DateTime expirationDate { get; set; }
        [Required]
        public string? cardholderName { get; set; }
    }
}
