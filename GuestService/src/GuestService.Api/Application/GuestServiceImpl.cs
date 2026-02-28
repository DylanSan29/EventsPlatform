using GuestService.Api.Application.Interfaces;
using GuestService.Api.Domain;
using GuestService.Api.Infrastructure.Repositories;

namespace GuestService.Api.Application
{
    public class GuestServiceImpl : IGuestService
    {
        private readonly IGuestRepository _repository;

        public GuestServiceImpl(IGuestRepository repository)
        {
            _repository = repository;
        }

        // 1. MATCHES INTERFACE: GetGuestInvitation
        public async Task<Guest?> GetGuestInvitation(int guestId)
        {
            return await _repository.GetByIdAsync(guestId);
        }

        // 2. MATCHES INTERFACE: RespondToInvitation
        public async Task<bool> RespondToInvitation(int guestId, string status)
        {
            var guest = await _repository.GetByIdAsync(guestId);
            if (guest == null) return false;

            guest.Status = status;
            await _repository.UpdateAsync(guest);
            return true;
        }

        // 3. MATCHES INTERFACE: GenerateQrCode
        public async Task<string> GenerateQrCode(int guestId)
        {
            var guest = await _repository.GetByIdAsync(guestId);
            if (guest == null) return "Guest not found";
            
            // Returns the string data for the QR code
            return $"TICKET:{guest.EventName}-{guest.Id}-{guest.Invitee}";
        }
    }
}