namespace FoodFood.Data.Models;

public class Rating {
	public int    Id     { get; set; }
	public string Review { get; set; }
	public bool   UserId { get; set; }
	public int    Stars  { get; set; }
}