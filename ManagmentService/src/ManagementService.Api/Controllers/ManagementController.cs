using Microsoft.AspNetCore.Mvc;
using ManagementService.Api.Application.Interfaces;
using ManagementService.Api.Domain;

namespace ManagementService.Api.Controllers
{
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementService _service;

        public ManagementController(IManagementService service)
        {
            _service = service;
        }

        // 1. GET /event/{eventName}/guests (Modified to use string Name as ID)
        [HttpGet("event/{eventName}/guests")]
        public async Task<IActionResult> GetGuests(string eventName)
        {
            var guests = await _service.GetGuests(eventName);
            return Ok(guests);
        }

        // 2. POST /event/{eventName}/guests
        [HttpPost("event/{eventName}/guests")]
        public async Task<IActionResult> AddGuest(string eventName, [FromBody] GuestDto request)
        {
            await _service.CreateGuest(eventName, request);
            return Ok(new { message = "Guest Added" });
        }

        // 3. PATCH /guests/{guestId}
        [HttpPatch("guests/{guestId}")]
        public async Task<IActionResult> UpdateGuest(int guestId, [FromBody] GuestDto request)
        {
            var success = await _service.UpdateGuest(guestId, request);
            if (!success) return NotFound("Guest not found");
            return Ok(new { message = "Guest Updated" });
        }

        // 4. DELETE /guests/{guestId}
        [HttpDelete("guests/{guestId}")]
        public async Task<IActionResult> DeleteGuest(int guestId)
        {
            var success = await _service.DeleteGuest(guestId);
            if (!success) return NotFound("Guest not found");
            return Ok(new { message = "Guest Deleted" });
        }
    }
}