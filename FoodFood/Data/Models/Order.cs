namespace FoodFood.Controller;

public class Order {
	public int        Id                 { get; set; }
	public bool       PreviousExperience { get; set; }
	public DateTime   OrderDate          { get; set; }
	public bool       IsDelivered        { get; set; }
	public double     TotalPrice         { get; set; }
	public MealOrder? MealOrder          { get; set; }
}