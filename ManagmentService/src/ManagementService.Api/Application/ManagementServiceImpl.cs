using ManagementService.Api.Application.Interfaces;
using ManagementService.Api.Domain;
using ManagementService.Api.Infrastructure.Repositories;

namespace ManagementService.Api.Application
{
    public class ManagementServiceImpl : IManagementService
    {
        private readonly IManagementRepository _repository;

        public ManagementServiceImpl(IManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Guest>> GetGuests(string eventName)
        {
            return await _repository.GetGuestsByEventAsync(eventName);
        }

        public async Task<bool> CreateGuest(string eventName, GuestDto guestDto)
        {
            // 1. Get the event from the repository first to get its ID
            // Note: You might need to add a "GetEventByName" method to your repository
            // For now, let's assume we use the ID from the guestDto if available,
            // or you can hardcode '1' just to test it.

            var newGuest = new Guest
            {
                EventId = 1, // <--- Add this line (Use 1 for your BodaAngelAle test)
                EventName = eventName,
                Invitee = guestDto.Invitee,
                Title = guestDto.Title,
                Status = "Pending",
                Description = "Added via API",
            };

            await _repository.AddGuestAsync(newGuest);
            return true;
        }

        public async Task<bool> UpdateGuest(int guestId, GuestDto guestDto)
        {
            var guest = await _repository.GetGuestByIdAsync(guestId);
            if (guest == null)
                return false;

            guest.Invitee = guestDto.Invitee;
            guest.Title = guestDto.Title;

            await _repository.UpdateGuestAsync(guest);
            return true;
        }

        public async Task<bool> DeleteGuest(int guestId)
        {
            var guest = await _repository.GetGuestByIdAsync(guestId);
            if (guest == null)
                return false;

            await _repository.DeleteGuestAsync(guest);
            return true;
        }
    }
}
