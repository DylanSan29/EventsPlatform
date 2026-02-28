using ManagementService.Api.Domain;

namespace ManagementService.Api.Infrastructure.Repositories
{
    public interface IManagementRepository
    {
        Task<List<Guest>> GetGuestsByEventAsync(string eventName);
        Task<Guest?> GetGuestByIdAsync(int id);
        Task AddGuestAsync(Guest guest);
        Task UpdateGuestAsync(Guest guest);
        Task DeleteGuestAsync(Guest guest);
    }
}