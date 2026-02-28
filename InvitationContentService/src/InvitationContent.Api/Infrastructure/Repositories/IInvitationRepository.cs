using InvitationContent.Api.Domain;

namespace InvitationContent.Api.Infrastructure.Repositories
{
    public interface IInvitationRepository
    {
        Task<Event?> GetEventByIdAsync(int eventId);
        Task<List<EventSection>> GetSectionsByEventIdAsync(int eventId);
        Task<List<EventImage>> GetImagesByEventIdAsync(int eventId);
    }
}