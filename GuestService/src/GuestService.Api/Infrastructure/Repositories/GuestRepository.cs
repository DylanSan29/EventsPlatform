using Microsoft.EntityFrameworkCore;
using GuestService.Api.Domain;
using GuestService.Api.Infrastructure.Data;

namespace GuestService.Api.Infrastructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly GuestDbContext _context;

        public GuestRepository(GuestDbContext context)
        {
            _context = context;
        }

        public async Task<Guest?> GetByIdAsync(int id)
        {
            // Maps to your Guests table (InviteList)
            return await _context.Guests.FindAsync(id);
        }

        public async Task UpdateAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
        }
    }
}