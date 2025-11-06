using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class RSVP
    {
        // Primary Key
        public int RsvpId { get; set; }

        // Foreign Key to the Event
        [Required]
        public int EventId { get; set; }

        // Attendee Details
        [Required]
        [MaxLength(100)]
        public string AttendeeName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string AttendeeEmail { get; set; }

        // Confirmation Status (set to true by default on submission)
        public bool IsConfirmed { get; set; } = true;

        // Additional Information
        [MaxLength(500)]
        public string Comment { get; set; }

        // Metadata: Date of the RSVP
        public DateTime RsvpDate { get; set; } = DateTime.UtcNow;

        // Note: Add a navigation property to the Event model here if using Entity Framework Core
        // public Event Event { get; set; } 
    
}
}
