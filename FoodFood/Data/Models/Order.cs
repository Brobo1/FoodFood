using FoodFood.Data.Models;

namespace FoodFood.Controller;

public class Order {
	public int        Id                 { get; set; }
	public bool       PreviousExperience { get; set; }
	public DateTime   OrderDate          { get; set; }
	public bool       IsDelivered        { get; set; }
	public double     TotalPrice         { get; set; }
	public ICollection<Meal_Order> Meal_Order { get; set; } = new List<Meal_Order>();
	public User? User { get; set; }
}