using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventBookingSystem.Data;
using EventBookingSystem.Models;

namespace EventBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly EventContext _context;
        public UsersController(EventContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            return Ok(await _context.Users.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var UserName = await _context.Users.FindAsync(id);

            if (UserName == null)
            {
                return NotFound();
            }

            return UserName;
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User userName)
        {
            _context.Users.Add(userName);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = userName.Id }, userName);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser (int Id, User userName)
        {

            if (Id != userName.Id)
            {

                return BadRequest();
            }


            _context.Entry(userName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await UserExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var userName = await _context.Users.FindAsync(id);

            if (userName == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userName);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private async Task<bool> UserExists(int id)
        {

            return await _context.Users.AnyAsync(e => e.Id == id);
        }
    
}
}
