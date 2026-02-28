using GuestService.Api.Domain;

namespace GuestService.Api.Application.Interfaces
{
    public interface IGuestService
    {
        Task<Guest?> GetGuestInvitation(int guestId);
        Task<bool> RespondToInvitation(int guestId, string status);
        Task<string> GenerateQrCode(int guestId);
    }
}