using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller 
{
	[Route("/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase 
    {
        private readonly FoodFoodContext _db;

        public PaymentController(FoodFoodContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var payment = await _db.Payment.FindAsync(id);
            if(payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var payments = await _db.Payment.ToListAsync();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PaymentModel paymentPost)
        {
            Payment payment = new Payment()
            {
                Type = paymentPost.Type!,
                CardNumber = paymentPost.CardNumber,
                ExpirationDate = paymentPost.ExpirationDate,
                CardHolderName = paymentPost.CardHolderName!
            };
            _db.Payment.Add(payment);
            await _db.SaveChangesAsync();
            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PaymentModel paymentPut)
        {
            var paymentToPut = await _db.Payment.FindAsync(id);
            if(paymentToPut == null) 
            {
                return NotFound();
            }
            paymentToPut.Type = paymentPut.Type!;
            paymentToPut.CardNumber = paymentPut.CardNumber;
            paymentToPut.ExpirationDate = paymentPut.ExpirationDate;
            paymentToPut.CardHolderName = paymentPut.CardHolderName!;

            await _db.SaveChangesAsync();
            return Ok(paymentToPut);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var paymentToDelete = await _db.Payment.FindAsync(id);

            if(paymentToDelete == null)
            {
                return NotFound();
            }
            _db.Payment.Remove(paymentToDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
