using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventBookingSystem.Data;
using EventBookingSystem.Models;

namespace EventBookingSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly EventContext _context;
        public EventController(EventContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEvent()
        {

            return Ok(await _context.Events.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var EventName = await _context.Events.FindAsync(id);

            if (EventName == null)
            {
                return NotFound(); 
            }

            return EventName; 
        }

        
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event EventName)
        {
            _context.Events.Add(EventName); 
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetEvent), new { id = EventName.Id }, EventName);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event EventName)
        {
            
            if (id != EventName.Id)
            {
                
                return BadRequest();
            }

            
            _context.Entry(EventName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                
                if (!await EventExists(id))
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
        public async Task<IActionResult> DeleteEvent(int id)
        {
           
            var EventName = await _context.Events.FindAsync(id);

            if (EventName == null)
            {
                return NotFound(); 
            }

            _context.Events.Remove(EventName);
            await _context.SaveChangesAsync(); 

            return NoContent();
        }

      
        private async Task<bool> EventExists(int id)
        {
            
            return await _context.Events.AnyAsync(e => e.Id == id);
        }
    }
}
