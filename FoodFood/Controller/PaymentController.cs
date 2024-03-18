using FoodFood.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodFood.Controller
{
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly FoodFoodContext _context;

        public PaymentController(ILogger<PaymentController> logger, FoodFoodContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create()
    }
}
