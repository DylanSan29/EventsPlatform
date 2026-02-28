using Microsoft.AspNetCore.Mvc;
using InvitationContent.Api.Application.Interfaces;

namespace InvitationContent.Api.Controllers
{
    [ApiController]
    [Route("events")] // Sets the base route for the diagram requirements
    public class InvitationContentController : ControllerBase
    {
        private readonly IInvitationContentService _service;

        public InvitationContentController(IInvitationContentService service)
        {
            _service = service;
        }

        // GET /events/{eventId}
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEvent(int eventId)
        {
            var result = await _service.GetEventDetails(eventId);
            if (result == null) return NotFound("Event not found");
            return Ok(result);
        }

        // GET /events/{eventId}/sections
        [HttpGet("{eventId}/sections")]
        public async Task<IActionResult> GetSections(int eventId)
        {
            var result = await _service.GetContentSections(eventId);
            return Ok(result);
        }

        // GET /events/{eventId}/images
        [HttpGet("{eventId}/images")]
        public async Task<IActionResult> GetImages(int eventId)
        {
            var result = await _service.GetEventImages(eventId);
            return Ok(result);
        }
    }
}