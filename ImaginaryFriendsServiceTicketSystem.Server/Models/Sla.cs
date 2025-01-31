using System.Text.Json.Serialization;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class Sla
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; }
    }
}
