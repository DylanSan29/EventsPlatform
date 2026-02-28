using InvitationContent.Api.Application.Interfaces;
using InvitationContent.Api.Domain;
using InvitationContent.Api.Infrastructure.Repositories;

namespace InvitationContent.Api.Application
{
    public class InvitationContentService : IInvitationContentService
    {
        private readonly IInvitationRepository _repository;

        public InvitationContentService(IInvitationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Event?> GetEventDetails(int id)
        {
            return await _repository.GetEventByIdAsync(id);
        }

        public async Task<List<EventSection>> GetContentSections(int eventId)
        {
            return await _repository.GetSectionsByEventIdAsync(eventId);
        }

        public async Task<List<EventImage>> GetEventImages(int eventId)
        {
            return await _repository.GetImagesByEventIdAsync(eventId);
        }
    }
}