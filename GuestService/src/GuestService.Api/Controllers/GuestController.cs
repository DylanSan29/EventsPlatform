using Microsoft.AspNetCore.Mvc;
using GuestService.Api.Application.Interfaces;
using GuestService.Api.Domain;

namespace GuestService.Api.Controllers
{
    [ApiController]
    [Route("guests")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _service;

        public GuestController(IGuestService service)
        {
            _service = service;
        }

        // GET /guests/{guestId}/invitation
        [HttpGet("{guestId}/invitation")]
        public async Task<IActionResult> GetInvitation(int guestId)
        {
            // FIX: Changed from GetInvitation to GetGuestInvitation
            var guest = await _service.GetGuestInvitation(guestId);
            
            if (guest == null) return NotFound("Invitation not found");
            return Ok(guest);
        }

        // POST /guests/{guestId}/invitation
        [HttpPost("{guestId}/invitation")]
        public async Task<IActionResult> RespondInvitation(int guestId, [FromBody] RsvpRequest request)
        {
            // FIX: Changed from Rsvp to RespondToInvitation
            var success = await _service.RespondToInvitation(guestId, request.Status);
            
            if (!success) return NotFound("Invitation not found");
            return Ok(new { message = "RSVP Updated" });
        }

        // GET /guests/{guestId}/qr
        [HttpGet("{guestId}/qr")]
        public async Task<IActionResult> GetQr(int guestId)
        {
            // FIX: Changed from GetQrCode to GenerateQrCode
            var qrString = await _service.GenerateQrCode(guestId);
            
            return Ok(new { qrCode = qrString });
        }
    }
}