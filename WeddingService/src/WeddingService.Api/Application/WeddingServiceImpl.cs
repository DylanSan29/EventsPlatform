using WeddingService.Api.Domain;
using WeddingService.Infrastructure;

namespace WeddingService.Application;

public class WeddingServiceImpl : IWeddingService
{
    private readonly IWeddingRepository _repository;

    public WeddingServiceImpl(IWeddingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Wedding> CreateAsync(Wedding wedding)
    {
        return await _repository.CreateAsync(wedding);
    }

    public async Task<Wedding?> GetMineAsync(Guid ownerId)
    {
        return await _repository.GetByOwnerAsync(ownerId);
    }

    public async Task<Wedding?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Wedding> UpdateAsync(Guid id, Guid ownerId, Wedding data)
    {
        var wedding = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Wedding not found");

        if (wedding.OwnerId != ownerId)
            throw new UnauthorizedAccessException();

        wedding.Title = data.Title;
        wedding.WeddingDate = data.WeddingDate;
        wedding.Location = data.Location;
        wedding.Description = data.Description;
        wedding.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(wedding);
        return wedding;
    }

}
