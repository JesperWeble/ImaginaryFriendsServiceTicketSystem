using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImaginaryFriendsServiceTicketSystem.Server.Models;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly TicketContext _context;
        private static readonly List<Status> statuses = new();
        private readonly ILogger<StatusController> _logger;
        public StatusController(TicketContext context, ILogger<StatusController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllStatuses")]
        public List<Status> GetAllStatuses()
        {
            return _context.Statuses.ToList();
        }

        [HttpGet]
        [Route("GetStatusById")]
        public Status GetStatusById(int id)
        {
            return _context.Statuses.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
