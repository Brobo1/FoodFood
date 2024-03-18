using FoodFood.Data.Models;

namespace FoodFood.Controller.ControllerModels
{
    public class PersonaliaModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Address { get; set; } = string.Empty;
        public int UserId { get; set; }

    }
}
