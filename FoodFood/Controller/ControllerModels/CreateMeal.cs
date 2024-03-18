using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFood.Controller.ControllerModels;

public class CreateMeal {
	public string Name        { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Category    { get; set; } = string.Empty;
	public string MealImage   { get; set; } = string.Empty;

	[Column(TypeName = "decimal(18,4)")]
	public decimal Price { get; set; }

	public string Allergens { get; set; } = string.Empty;
}