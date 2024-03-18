namespace FoodFood.Controller.ControllerModels;

public class CreateRestaurant {
	public string   Name        { get; set; } = string.Empty;
	public string   Address     { get; set; } = string.Empty;
	public string   Category    { get; set; } = string.Empty;
	public string   Description { get; set; } = string.Empty;
	public DateTime OpeningTime { get; set; } = DateTime.Now;
	public DateTime ClosingTime { get; set; } = DateTime.Now;
	public bool     IsOpen      { get; set; }
	public string   Image       { get; set; } = string.Empty;
}