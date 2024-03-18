using FoodFood.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodFood.Controller;

public class Meal_Order {
	public int Id      { get; set; }
	public int MealId  { get; set; }
	public int OrderId { get; set; }
	public Order? Order { get; set; }
	public Meal? Meal { get; set; }
}