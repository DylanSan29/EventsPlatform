using InvitationContent.Api.Domain;

namespace InvitationContent.Api.Application.Interfaces
{
    public interface IInvitationContentService
    {
        Task<Event?> GetEventDetails(int id);
        Task<List<EventSection>> GetContentSections(int eventId);
        Task<List<EventImage>> GetEventImages(int eventId);
    }
}