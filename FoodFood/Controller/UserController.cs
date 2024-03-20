using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using FoodFood.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _db.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _db.User.ToListAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUser user)
        {
            if (ModelState.IsValid == false)
            {
                return ValidationProblem(ModelState);
            }

            var generatedSalt = PasswordHasher.GenerateSalt();

            User newUser = new ()
            {
                UserName = user.UserName,
                Password = PasswordHasher.HashPassword(user.Password + PasswordHasher.GenerateSalt())
            };
            _db.User.Add(newUser);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id}, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _db.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _db.User.Remove(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, CreateUser user)
        {
            var userToUpdate = await _db.User.FindAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            userToUpdate.UserName = user.UserName;
            userToUpdate.Password = PasswordHasher.HashPassword(user.Password + PasswordHasher.GenerateSalt());
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
