using Microsoft.EntityFrameworkCore;
using ManagementService.Api.Domain;
using ManagementService.Api.Infrastructure.Data;

namespace ManagementService.Api.Infrastructure.Repositories
{
    public class ManagementRepository : IManagementRepository
    {
        private readonly ManagementDbContext _context;

        public ManagementRepository(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guest>> GetGuestsByEventAsync(string eventName)
        {
            // Assuming we filter by EventName string as per your early diagrams
            return await _context.Guests.Where(g => g.EventName == eventName).ToListAsync();
        }

        public async Task<Guest?> GetGuestByIdAsync(int id)
        {
            return await _context.Guests.FindAsync(id);
        }

        public async Task AddGuestAsync(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuestAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuestAsync(Guest guest)
        {
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }
}