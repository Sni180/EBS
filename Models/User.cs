using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventBookingSystem.Models
{
    
    public class User
    {
      
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
       
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Full Name must be at least 5 characters long and no more than 100.")]
       
        [Column("FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Email Address must be valid.")]
        
        [Column("EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        
        [Column("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "User Type is required.")]
        
        [RegularExpression("^(Admin|Organizer|Customer)$", ErrorMessage = "Type must be one of: 'Admin', 'Organizer', or 'Customer'.")]
     
        [Column("UserType")]
        public string UserType { get; set; }

       
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}