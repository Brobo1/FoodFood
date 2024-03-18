using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodFood.Controller;

public class MealOrder {
	public int Id      { get; set; }
	public int MealId  { get; set; }
	public int OrderId { get; set; }
	public ICollection<Order>? Orders   { get; set; }
}