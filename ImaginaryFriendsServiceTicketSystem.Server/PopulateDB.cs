using System.Security.Cryptography.X509Certificates;
using ImaginaryFriendsServiceTicketSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ImaginaryFriendsServiceTicketSystem.Server
{
    public class PopulateDB
    {
        private static TicketContext _context;
        public static void Populate(string ConStr)
        {
            _context = new TicketContext(new DbContextOptionsBuilder<TicketContext>().UseMySql(ConStr, ServerVersion.AutoDetect(ConStr)).Options);
            //services.GetRequiredService<TicketContext>();
            using (var context = _context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var slas = new[]
                {
                    new Sla { Name = "Gold" },
                    new Sla { Name = "Silver" },
                    new Sla { Name = "Bronze" }
                };
                context.Slas.AddRange(slas);
                context.SaveChanges();

                var customers = new[]
                {
                    new Customer { FName = "John", LName = "Doe", SlaId = 1 },
                    new Customer { FName = "Jane", LName = "Smith", SlaId = 2 },
                    new Customer { FName = "Bob", LName = "Brown", SlaId = 3 }
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();

                var levels = new[]
                {
                    new Level { Name = "1" },
                    new Level { Name = "2" },
                    new Level { Name = "3" }
                };
                context.Levels.AddRange(levels);  
                context.SaveChanges();

                var statuses = new[]
                {
                    new Status { Name = "New" },
                    new Status { Name = "Open" },
                    new Status { Name = "Pending" },
                    new Status { Name = "On Hold" },
                    new Status { Name = "Solved" },
                    new Status { Name = "Closed" }
                };
                context.Statuses.AddRange(statuses);
                context.SaveChanges();

                var users = new[]
                {
                    new User { Name = "John Doe" },
                    new User { Name = "Jane Smith" },
                    new User { Name = "Bob Brown" }
                };
                context.Users.AddRange(users);
                context.SaveChanges();

                var tickets = new[]
                {
                    new Ticket { Title = "Ticket 1", Description = "Description 1", UserId = 1, CustomerId = 1, UpdatedAt = DateTime.Now, StatusId = 1, LevelId = 1 },
                    new Ticket { Title = "Ticket 2", Description = "Description 2", UserId = 2, CustomerId = 2, UpdatedAt = DateTime.Now, StatusId = 2, LevelId = 2 },
                    new Ticket { Title = "Ticket 3", Description = "Description 3", UserId = 3, CustomerId = 3, UpdatedAt = DateTime.Now, StatusId = 3, LevelId = 3 }
                };
                context.Tickets.AddRange(tickets);
                context.SaveChanges();
            }
        }
    }
}
