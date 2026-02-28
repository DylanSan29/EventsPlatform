using GuestService.Api.Domain;

namespace GuestService.Api.Infrastructure.Repositories
{
    public interface IGuestRepository
    {
        // We only want Guest methods now, not Event methods
        Task<Guest?> GetByIdAsync(int id);
        Task UpdateAsync(Guest guest);
    }
}