using FoodFood.Controller.ControllerModels;
using FoodFood.Data;
using FoodFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodFood.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class PersonaliaController : ControllerBase
    {
        private readonly FoodFoodContext _db;

        public PersonaliaController(FoodFoodContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) 
        {
            var personalia = await _db.Personalia.FindAsync(id);
            if(personalia == null) 
            {
                return NotFound();
            }
            return Ok(personalia);
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var payments = await _db.Payment.ToListAsync();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonaliaModel personaliaCreate)
        {
            Personalia personalia = new Personalia()
            {
                FirstName = personaliaCreate.FirstName,
                LastName = personaliaCreate.LastName,
                Birthday = personaliaCreate.Birthday,
                Address = personaliaCreate.Address,
                UserId = personaliaCreate.UserId,
            };
            _db.Personalia.Add(personalia);
            await _db.SaveChangesAsync();
            return Ok(personalia);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(PersonaliaModel personaliaPut, int id)
        {
            var personaliaToPut = await _db.Personalia.FindAsync(id);
            if(personaliaToPut == null)
            {
                return NotFound();
            }
            personaliaToPut.FirstName = personaliaPut.FirstName;
            personaliaToPut.LastName = personaliaPut.LastName;
            personaliaToPut.Birthday = personaliaPut.Birthday;
            personaliaToPut.Address = personaliaPut.Address;

            await _db.SaveChangesAsync();
            return Ok(personaliaToPut);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var personaliaToDelete = await _db.Personalia.FindAsync(id);

            if (personaliaToDelete == null)
            {
                return NotFound();
            }
            _db.Personalia.Remove(personaliaToDelete);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
