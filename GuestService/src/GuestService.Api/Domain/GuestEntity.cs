using System.ComponentModel.DataAnnotations.Schema;

namespace GuestService.Api.Domain
{
    [Table("InviteList")] // Crucial: Maps to the existing table
    public class Guest
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string? Invitee { get; set; } // The Guest Name
        public string? Status { get; set; } // "Pending", "Confirmed", "Declined"
        
        // Optional fields from your diagram if needed:
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    // A small DTO for the RSVP body
    public class RsvpRequest
{
    public string Status { get; set; } = string.Empty; // Initialize it to avoid the warning
}
}