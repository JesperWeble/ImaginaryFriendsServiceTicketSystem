using Microsoft.EntityFrameworkCore;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Sla> Slas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Level>().ToTable("Level");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Sla>().ToTable("Sla");
        }
    }
}
