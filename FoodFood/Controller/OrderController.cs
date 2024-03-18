using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodFood.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly FoodFoodContext _db;

        public OrderController(FoodFoodContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await _db.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order order)
        {
            _db.Order.Add(order);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, Order order)
        {

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _db.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _db.Order.Remove(order);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
    public class CreateOrder
    {
        public int Id { get; set; }
        

    }
}
