using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementService.Api.Domain
{
    [Table("InviteList")] // Maps to the shared SQL table
    public class Guest
    {
        public int Id { get; set; }
        public int EventId { get; set; } // We need this to filter by Event!
        public string EventName { get; set; } = string.Empty;
        public string? Invitee { get; set; }
        public string? Status { get; set; } = "Pending";
        
        // Fields for admin use
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    // DTO for adding/updating
    public class GuestDto
    {
        public required string Invitee { get; set; }
        public required string Title { get; set; }
    }
}