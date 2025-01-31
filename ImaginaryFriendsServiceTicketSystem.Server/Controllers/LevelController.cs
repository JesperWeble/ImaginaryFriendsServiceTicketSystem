using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImaginaryFriendsServiceTicketSystem.Server.Models;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    public class LevelController : ControllerBase
    {
        private readonly TicketContext _context;
        private static readonly List<Level> levels = new();

        private readonly ILogger<LevelController> _logger;

        public LevelController(TicketContext context, ILogger<LevelController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllLevels")]
        public List<Level> GetAllLevels()
        {
            return _context.Levels.ToList();
        }

        [HttpGet]
        [Route("GetLevelById")]
        public Level GetLevelById(int id)
        {
            return _context.Levels.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
