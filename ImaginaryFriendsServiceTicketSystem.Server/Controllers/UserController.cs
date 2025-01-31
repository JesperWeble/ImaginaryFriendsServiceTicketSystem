using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImaginaryFriendsServiceTicketSystem.Server.Models;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TicketContext _context;
        private static readonly List<User> users = new();
        private readonly ILogger<UserController> _logger;
        public UserController(TicketContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet]
        [Route("GetUserById")]
        public User GetUserById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser(User user)
        {
            string response = string.Empty;
            _context.Users.Add(user);
            _context.SaveChanges();
            return "User added successfully";
        }

        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return "User Updated";
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
            return "User Deleted";
        }
    }
}
