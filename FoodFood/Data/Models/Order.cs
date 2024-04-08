namespace FoodFood.Data.Models;

public class Order {
	public int                     Id           { get; set; }
	public DateTime                OrderDate    { get; set; }
	public bool                    IsDelivered  { get; set; }
	public double                  TotalPrice   { get; set; }
	public int                     UserId       { get; set; }
	public int                     RestaurantId { get; set; }
	public ICollection<MealOrder>? MealOrder    { get; set; }
	public User?                   User         { get; set; }
}