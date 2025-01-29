using ImaginaryFriendsServiceTicketSystem.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TicketController : ControllerBase
    {
        private static readonly Ticket[] tickets = new[]
        {
            new Ticket()
            {
                id = 1,
                title = "Ticket 1",
                description = "Description 1",
                userId = 1,
                customerId = 1,
                UpdatedAt = DateTime.Now,
                statusId = 1,
                levelId = 1
            },
            new Ticket()
            {
                id = 2,
                title = "Ticket 2",
                description = "Description 2",
                userId = 2,
                customerId = 2,
                UpdatedAt = DateTime.Now,
                statusId = 2,
                levelId = 2
            },
            new Ticket()
            {   id = 3,
                title = "Ticket 3",
                description = "Description 3",
                userId = 3,
                customerId = 3,
                UpdatedAt = DateTime.Now,
                statusId = 3,
                levelId = 3 }
        };

        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return tickets;
        }
    }
}
