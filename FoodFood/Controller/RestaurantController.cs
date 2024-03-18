using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller;

[Route("/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase {
	private readonly FoodFoodContext _db;

	public RestaurantController(FoodFoodContext context) {
		_db = context;
	}

	[HttpGet]
	public async Task<ActionResult> GetRestaurants() {
		return Ok(await _db.Restaurants.ToListAsync());
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult> GetRestaurant(int id) {
		var restaurant = await _db.Restaurants.FindAsync(id);
		if (restaurant == null) {
			return NotFound();
		}
		return Ok(restaurant);
	}

	[HttpPost]
	public async Task<ActionResult> CreateRestaurant(CreateRestaurant restaurant) {
		Restaurant newRestaurant = new() {
			Name        = restaurant.Name!,
			Address     = restaurant.Description!,
			Category    = restaurant.Category!,
			Description = restaurant.Description!,
			OpeningTime = restaurant.OpeningTime!,
			ClosingTime = restaurant.ClosingTime!,
			IsOpen      = restaurant.IsOpen,
			Image       = restaurant.Image,
		};
		_db.Restaurants.Add(newRestaurant);
		await _db.SaveChangesAsync();
		return CreatedAtRoute(new { id = newRestaurant.Id }, restaurant);
	}

	[HttpPut("{id:int}")]
	public async Task<ActionResult> UpdateRestaurant(int id, CreateRestaurant restaurant) {
		var restaurantToUpdate = await _db.Restaurants.FindAsync(id);
		if (restaurantToUpdate == null) {
			return NotFound();
		}
		restaurantToUpdate.Name        = restaurant.Name!;
		restaurantToUpdate.Address     = restaurant.Address!;
		restaurantToUpdate.Category    = restaurant.Category!;
		restaurantToUpdate.Description = restaurant.Description!;
		restaurantToUpdate.OpeningTime = restaurant.OpeningTime!;
		restaurantToUpdate.ClosingTime = restaurant.ClosingTime!;
		restaurantToUpdate.IsOpen      = restaurant.IsOpen;
		restaurantToUpdate.Image       = restaurant.Image;
		await _db.SaveChangesAsync();
		return NoContent();
	}

	[HttpDelete]
	public async Task<ActionResult> DeleteRestaurant(int id) {
		var restaurant = await _db.Restaurants.FindAsync(id);
		if (restaurant == null) {
			return NotFound();
		}
		_db.Restaurants.Remove(restaurant);
		await _db.SaveChangesAsync();
		return NoContent();
	}
}