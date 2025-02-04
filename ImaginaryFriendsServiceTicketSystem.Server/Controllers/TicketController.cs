using ImaginaryFriendsServiceTicketSystem.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketContext _ticketContext;
        private static readonly List<Ticket> tickets = new();

        private readonly ILogger<TicketController> _logger;

        public TicketController(TicketContext ticketContext, ILogger<TicketController> logger)
        {
            _ticketContext = ticketContext;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllTickets")]
        public List<Ticket> GetAllTickets()
        {
            return _ticketContext.Tickets.ToList();
        }

        [HttpGet]
        [Route("GetTicketById")]
        public Ticket? GetTicketById(int id)
        {
            return _ticketContext.Tickets.Find(id);
        }
        
        [HttpGet]
        [Route("GetFullTicketById")]
        public ActionResult<FullTicketInfoDto> GetFullTicketInfo(int id)
        {
            var ticket = _ticketContext.Tickets
                                    .Include(ticket => ticket.Customer)
                                        .ThenInclude(customer => customer.Sla)
                                    .Include(ticket => ticket.User)
                                    .Include(ticket => ticket.Level)
                                    .Include(ticket => ticket.Status)
                                    .Where(ticket => ticket.Id == id)
                                    .FirstOrDefault();
            
            if (ticket == null)
            {
                return NotFound();
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
            // Map to the DTO
            var ticketDto = new FullTicketInfoDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                UpdatedAt = ticket.UpdatedAt,
                Customer = new CustomerDto
                {
                    Id = ticket.Customer.Id,
                    FName = ticket.Customer.FName,
                    LName = ticket.Customer.LName,
                    Sla = ticket.Customer.Sla == null ? null : new SlaDto
                    {
                        SlaId = ticket.Customer.Sla.Id,
                        Name = ticket.Customer.Sla.Name
                    }
                },
                User = new UserDto
                {
                    Id = ticket.User.Id,
                    Username = ticket.User.Name
                },
                Level = new LevelDto
                {
                    Id = ticket.Level.Id,
                    Name = ticket.Level.Name
                },
                Status = new StatusDto
                {
                    Id = ticket.Status.Id,
                    Name = ticket.Status.Name
                }
            };
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return Ok(ticketDto);
        }

        [HttpPost]
        [Route("AddTicket")]
        public string AddTicket(Ticket ticket)
        {
            string response = string.Empty;
            _ticketContext.Tickets.Add(ticket);
            _ticketContext.SaveChanges();
            return "User added successfully";
        }

        [HttpPut]
        [Route("UpdateTicket")]
        public string UpdateTicket(Ticket ticket)
        {
            _ticketContext.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _ticketContext.SaveChanges();

            return "Ticket Updated";
        }

        [HttpDelete]
        [Route("DeleteTicket")]
        public string DeleteTicket(int  id)
        {
            var ticket = _ticketContext.Tickets.Find(id);
            if (ticket == null)
            {
                return "Ticket not found";
            }
            _ticketContext.Remove(ticket);
            _ticketContext.SaveChanges();

            return "Ticket Deleted";
        }
    }
}
