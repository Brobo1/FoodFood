using System.ComponentModel.DataAnnotations.Schema;



namespace FoodFood.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string MealImage { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }
        public string Allergens { get; set; } = string.Empty;
        public ICollection<MealOrder>? MealOrders { get; set; }

        public Restaurant? Restaurant { get; set; }
        
    }
}
