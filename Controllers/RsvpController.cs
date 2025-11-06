using EventBookingSystem.Data;
using EventBookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RsvpController : ControllerBase
    {
        private readonly EventContext _context; 

        public RsvpController(EventContext context)
        {
            _context = context;
        }

     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RSVP>> PostRsvp([FromBody] RSVP rsvp)
        {
           
            if (rsvp == null || rsvp.EventId <= 0)
            {
                return BadRequest("RSVP data or Event ID is invalid.");
            }

            
            rsvp.RsvpDate = DateTime.UtcNow;
            rsvp.IsConfirmed = true;

            // Add the new RSVP to the database context
            _context.rsvp.Add(rsvp);

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                
                return StatusCode(500, $"Internal server error while saving RSVP: {ex.Message}");
            }

            
            return CreatedAtAction(nameof(GetRsvp), new { id = rsvp.RsvpId }, rsvp);
        }

    
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RSVP>> GetRsvp(int id)
        {
            var rsvp = await _context.rsvp.FindAsync(id);

            if (rsvp == null)
            {
                return NotFound();
            }

            return Ok(rsvp);
        }
    }
}

