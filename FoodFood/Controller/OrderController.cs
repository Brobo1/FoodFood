using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var orders = await _db.Order.ToListAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrder order)
        {
            Order newOrder = new ()
            {
                OrderDate = order.OrderDate,
                IsDelivered = order.IsDelivered,
                TotalPrice = order.TotalPrice
            };
            _db.Order.Add(newOrder);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, Order order)
        {
           var existingOrder = await _db.Order.FindAsync(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.OrderDate = order.OrderDate;
            existingOrder.IsDelivered = order.IsDelivered;
            existingOrder.TotalPrice = order.TotalPrice;

            await _db.SaveChangesAsync();

            return NoContent();
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
   
}
