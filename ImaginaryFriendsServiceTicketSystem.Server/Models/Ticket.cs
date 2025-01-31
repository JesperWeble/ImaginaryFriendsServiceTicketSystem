using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int StatusId { get; set; }
        [JsonIgnore]
        public Status? Status { get; set; }

        public int LevelId { get; set; }
        [JsonIgnore]
        public Level? Level { get; set; }
    }
}
