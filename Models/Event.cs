using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EventBookingSystem.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        public string EventName { get; set; }


        [Required(ErrorMessage = "Event description is required.")]
        public string EventDescription { get; set; }

        
        [Required(ErrorMessage = "Date is required.")]
        public DateOnly Date { get; set; }

       
        [Required(ErrorMessage = "Time is required.")]
        public TimeOnly Time { get; set; }

        
        [Required(ErrorMessage = "Venue is required.")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("(Draft|Pending|Approved)$", ErrorMessage = "Status must be 'Draft', 'Pending', or 'Approved'.")]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
