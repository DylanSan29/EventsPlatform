using Microsoft.EntityFrameworkCore;
using InvitationContent.Api.Domain;
using InvitationContent.Api.Infrastructure.Data;

namespace InvitationContent.Api.Infrastructure.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly InvitationContentDbContext _context;

        public InvitationRepository(InvitationContentDbContext context)
        {
            _context = context;
        }

        public async Task<Event?> GetEventByIdAsync(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task<List<EventSection>> GetSectionsByEventIdAsync(int eventId)
        {
            // Requires EventId column in EventSection table
            return await _context.EventSections
                                 .Where(s => s.EventId == eventId) 
                                 .ToListAsync();
        }

        public async Task<List<EventImage>> GetImagesByEventIdAsync(int eventId)
        {
            return await _context.EventImages
                                 .Where(i => i.EventId == eventId)
                                 .ToListAsync();
        }
    }
}