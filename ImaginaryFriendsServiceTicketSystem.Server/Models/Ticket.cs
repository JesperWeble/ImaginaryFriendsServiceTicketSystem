using System.ComponentModel.DataAnnotations;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class Ticket
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public int customerId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int statusId { get; set; }
        public int levelId { get; set; }
    }
}
