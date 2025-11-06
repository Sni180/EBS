using Microsoft.EntityFrameworkCore;
using EventBookingSystem.Models;

namespace EventBookingSystem.Data
{
    public class EventContext : DbContext
    {

        public EventContext(DbContextOptions<EventContext>options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RSVP> rsvp { get; set; }
    }
}
