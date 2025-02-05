namespace ImaginaryFriendsServiceTicketSystem.Server.Models
{
    public class FullTicketInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }  // Add fields from the Ticket model
        public DateTime UpdatedAt { get; set; }
        public CustomerDto Customer { get; set; }      // Include related data
        public UserDto User { get; set; }              // Include related data
        public LevelDto Level { get; set; }            // Include related data
        public StatusDto Status { get; set; }          // Include related data
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public SlaDto Sla { get; set; }  // Include nested related data
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LevelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SlaDto
    {
        public int SlaId { get; set; }
        public string Name { get; set; }
    }
}
