using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class MealOrderController : ControllerBase
    {
        private readonly FoodFoodContext _db;

        public MealOrderController(FoodFoodContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMealOrder(int id)
        {
            var mealOrder = await _db.MealOrder.FindAsync(id);
            if (mealOrder == null)
            {
                return NotFound();
            }
            return Ok(mealOrder);
        }

        [HttpGet]
        public async Task<ActionResult> GetMealOrders()
        {
            var mealOrders = await _db.MealOrder.ToListAsync();
            return Ok(mealOrders);
        }
        [HttpPost]
        public async Task<ActionResult> CreateMealOrder(CreateMealOrder mealOrder)
        {
            MealOrder newMealOrder = new ()
            {
                OrderId = mealOrder.OrderId,
                MealId = mealOrder.MealId,
                Quantity = mealOrder.Quantity
            };
            _db.MealOrder.Add(newMealOrder);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMealOrder), new { id = newMealOrder.Id}, newMealOrder);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMealOrder(int id)
        {
            var mealOrder = await _db.MealOrder.FindAsync(id);
            if (mealOrder == null)
            {
                return NotFound();
            }
            _db.MealOrder.Remove(mealOrder);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMealOrder(int id, CreateMealOrder mealOrder)
        {
            var mealOrderToUpdate = await _db.MealOrder.FindAsync(id);
            if (mealOrderToUpdate == null)
            {
                return NotFound();
            }
            mealOrderToUpdate.OrderId = mealOrder.OrderId;
            mealOrderToUpdate.MealId = mealOrder.MealId;
            mealOrderToUpdate.Quantity = mealOrder.Quantity;
            await _db.SaveChangesAsync();
            return NoContent();
        }


    }
}
