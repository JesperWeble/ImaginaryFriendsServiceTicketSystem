using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class AddTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int LevelId { get; set; }
    }
}
