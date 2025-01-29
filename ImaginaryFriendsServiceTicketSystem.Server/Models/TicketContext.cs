using Microsoft.EntityFrameworkCore;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
