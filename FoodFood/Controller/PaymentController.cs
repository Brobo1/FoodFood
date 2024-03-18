using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodFood.Controller
{
    public class PaymentController : ControllerBase
    {
        private readonly FoodFoodContext _context;

        public PaymentController(FoodFoodContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PaymentModel paymentPost)
        {
            Payment payment = new Payment()
            {
                Type = paymentPost.Type!,
                CardNumber = paymentPost.cardNumber,
                ExpirationDate = paymentPost.expirationDate,
                CardHolderName = paymentPost.cardholderName!
            };
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
            return Ok(payment);
        }

        //[HttpPut]
        //public async Task<ActionResult> Update(PaymentModel paymentPut)
        //{
        //    var paymentToPut = await _context.Payment.FindAsync(paymentPut.Id);

        //}
    }
}
