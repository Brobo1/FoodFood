﻿namespace FoodFood.Data.Models;

public class Rating {
	public int    Id     { get; set; }
	public string Review { get; set; } = string.Empty;
	public bool   UserId { get; set; }
	public int    Stars  { get; set; }
	public User?  User { get; set; }
	public ICollection<Restaurant_Rating> Restaurant_Rating { get; set; } = new List<Restaurant_Rating>();
}