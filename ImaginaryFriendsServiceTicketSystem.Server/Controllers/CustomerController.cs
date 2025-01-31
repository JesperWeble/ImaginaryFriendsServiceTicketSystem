using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImaginaryFriendsServiceTicketSystem.Server.Models;

namespace ImaginaryFriendsServiceTicketSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TicketContext _context;
        private static readonly List<Customer> customers = new();
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(TicketContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("AddCustomer")]
        public string AddCustomer(Customer customer)
        {
            string response = string.Empty;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return "Customer added successfully";
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public string UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return "Customer Updated";
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public string DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
            return "Customer Deleted";
        }
    }
}
