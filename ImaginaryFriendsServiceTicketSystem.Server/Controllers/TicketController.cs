using ImaginaryFriendsServiceTicketSystem.Server.Models;
using Microsoft.AspNetCore.Mvc;

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
        public Ticket GetTicketById(int id)
        {
            return _ticketContext.Tickets.Where(x => x.Id == id).FirstOrDefault();
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
        public string DeleteTicket(Ticket ticket)
        {
            _ticketContext.Remove(ticket);
            _ticketContext.SaveChanges();

            return "Ticket Deleted";
        }
    }
}
