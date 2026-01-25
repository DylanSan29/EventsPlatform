namespace WeddingService.Api.Domain;

public class Wedding
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime WeddingDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
