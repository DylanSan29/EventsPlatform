using ManagementService.Api.Domain;

namespace ManagementService.Api.Application.Interfaces
{
    public interface IManagementService
    {
        Task<List<Guest>> GetGuests(string eventName);
        Task<bool> CreateGuest(string eventName, GuestDto guestDto);
        Task<bool> UpdateGuest(int guestId, GuestDto guestDto);
        Task<bool> DeleteGuest(int guestId);
    }
}