using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeddingService.Application;
using WeddingService.Api.Domain;

namespace WeddingService.Api.Controllers;

[ApiController]
[Route("api/weddings")]
public class WeddingsController : ControllerBase
{
    private readonly IWeddingService _service;

    public WeddingsController(IWeddingService service)
    {
        _service = service;
    }

    // 🔐 Helper to safely extract userId from JWT
    private bool TryGetUserId(out Guid userId)
    {
        userId = Guid.Empty;
        var claim = User.FindFirstValue("userId");
        return !string.IsNullOrWhiteSpace(claim) && Guid.TryParse(claim, out userId);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(Wedding wedding)
    {
        if (!TryGetUserId(out var userId))
            return Unauthorized();

        wedding.OwnerId = userId;
        return Created(string.Empty, await _service.CreateAsync(wedding));
    }

    [Authorize]
    [HttpGet("my")]
    public async Task<IActionResult> GetMine()
    {
        if (!TryGetUserId(out var userId))
            return Unauthorized();

        return Ok(await _service.GetMineAsync(userId));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Wedding wedding)
    {
        if (!TryGetUserId(out var userId))
            return Unauthorized();

        return Ok(await _service.UpdateAsync(id, userId, wedding));
    }
}
