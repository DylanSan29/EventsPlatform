namespace InvitationContent.Api.Domain
{
    // Maps to your 'Event' table
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // Maps to your 'EventSection' table
    public class EventSection
    {
        public int Id { get; set; }
        public int EventId { get; set; } // Ensure your DB table has this FK!
        public string Title { get; set; }
        public string Content { get; set; }
    }

    // Maps to the new 'EventImage' table
    public class EventImage
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageType { get; set; }
    }
}