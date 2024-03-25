using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller;

[Route("/[controller]")]
[ApiController]
public class MealController : ControllerBase {
	private readonly FoodFoodContext _db;

	public MealController(FoodFoodContext db) {
		_db = db;
	}

	[HttpGet]
	public async Task<ActionResult> GetMeals() {
		return Ok(await _db.Meal.ToListAsync());
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult> GetMeal(int id) {
		var meal = await _db.Meal.FindAsync(id);
		if (meal == null) {
			return NotFound();
		}
		return Ok(meal);
	}	
	
	[HttpGet("mealRest/{id:int}")]
	public async Task<ActionResult> GetMealByRestaurant(int id) {
		var meal = await _db.Meal.Where(m => m.RestaurantId == id).ToListAsync();
		if (meal.Count <= 0) {
			return NotFound();
		}
		return Ok(meal);
	}

	[HttpPost]
	public async Task<ActionResult> CreateMeal(CreateMeal meal) {
		Meal newMeal = new() {
			Name        = meal.Name!,
			Description = meal.Description!,
			Price       = meal.Price,
			Category    = meal.Category,
			MealImage   = meal.MealImage,
			Allergens   = meal.Allergens,
			RestaurantId = meal.RestaurantId,
			IsActive = meal.IsActive,
		};
		_db.Meal.Add(newMeal);
		await _db.SaveChangesAsync();
		return CreatedAtRoute(new { id = newMeal.Id }, newMeal);
	}

	[HttpPut("{id:int}")]
	public async Task<ActionResult> UpdateMeal(int id, CreateMeal meal) {
		var mealToUpdate = await _db.Meal.FindAsync(id);
		if (mealToUpdate == null) {
			return NotFound();
		}
		mealToUpdate.Name        = meal.Name!;
		mealToUpdate.Description = meal.Description!;
		mealToUpdate.Price       = meal.Price;
		mealToUpdate.Category    = meal.Category;
		mealToUpdate.MealImage   = meal.MealImage;
		mealToUpdate.Allergens = meal.Allergens;
		mealToUpdate.RestaurantId = meal.RestaurantId;
		mealToUpdate.IsActive = meal.IsActive;
		await _db.SaveChangesAsync();
		return NoContent();
	}

	[HttpDelete("{id:int}")]
	public async Task<ActionResult> DeleteMeal(int id) {
		var meal = await _db.Meal.FindAsync(id);
		if (meal == null) {
			return NotFound();
		}
		_db.Meal.Remove(meal);
		await _db.SaveChangesAsync();
		return NoContent();
	}
}