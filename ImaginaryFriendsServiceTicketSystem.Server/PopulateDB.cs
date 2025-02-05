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

                var ticketTitles = new[]
                {
                        "Login Issue",
                        "Payment Failure",
                        "Account Locked",
                        "Feature Request",
                        "Bug Report",
                        "Performance Issue",
                        "Data Sync Problem",
                        "UI Glitch",
                        "Security Concern",
                        "Other"
                    };

                var ticketDescriptions = new[]
                {
                        "Unable to login with correct credentials.",
                        "Payment gateway is not processing transactions.",
                        "Account is locked after multiple failed login attempts.",
                        "Requesting a new feature for the application.",
                        "Found a bug in the latest release.",
                        "Application performance is slow.",
                        "Data is not syncing between devices.",
                        "UI elements are not displaying correctly.",
                        "Concern about the security of the application.",
                        "General inquiry or issue."
                    };

                // Make Random Tickets
                var random = new Random();
                int numberOfTickets = 30; // Set the number of tickets to create

                var tickets = new List<Ticket>();
                for (int i = 0; i < numberOfTickets; i++)
                {
                    tickets.Add(new Ticket
                    {
                        Title = ticketTitles[random.Next(ticketTitles.Length)],
                        Description = ticketDescriptions[random.Next(ticketDescriptions.Length)],
                        UserId = random.Next(1, users.Length + 1),
                        CustomerId = random.Next(1, customers.Length + 1),
                        UpdatedAt = DateTime.Now,
                        StatusId = random.Next(1, statuses.Length + 1),
                        LevelId = random.Next(1, levels.Length + 1)
                    });
                }
                context.Tickets.AddRange(tickets);
                context.SaveChanges();
            }
        }
    }
}
