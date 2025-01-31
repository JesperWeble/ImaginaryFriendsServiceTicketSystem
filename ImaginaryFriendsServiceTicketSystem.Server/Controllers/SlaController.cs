using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImaginaryFriendsServiceTicketSystem.Server.Models;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlaController : ControllerBase
    {
        private readonly TicketContext _context;
        private static readonly List<Sla> slas = new();
        private readonly ILogger<SlaController> _logger;
        public SlaController(TicketContext context, ILogger<SlaController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetAllSlas")]
        public List<Sla> GetAllSlas()
        {
            return _context.Slas.ToList();
        }
        [HttpGet]
        [Route("GetSlaById")]
        public Sla GetSlaById(int id)
        {
            return _context.Slas.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
