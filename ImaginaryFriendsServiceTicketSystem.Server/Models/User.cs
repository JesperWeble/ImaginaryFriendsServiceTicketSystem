using System.Text.Json.Serialization;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Ticket> Tickets { get; set; }
    }
}
