using FoodFood.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodFood.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FoodFoodContext _db;

        public UserController(FoodFoodContext db)
        {
            _db = db;
        }
        [HttpGet("{id}")]


    }
    public class CreateUser
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
