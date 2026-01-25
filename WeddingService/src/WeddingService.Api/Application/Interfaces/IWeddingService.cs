using WeddingService.Api.Domain;

namespace WeddingService.Application;

public interface IWeddingService
{
    Task<Wedding> CreateAsync(Wedding wedding);
    Task<Wedding?> GetMineAsync(Guid ownerId);
    Task<Wedding?> GetByIdAsync(Guid id);
    Task<Wedding> UpdateAsync(Guid id, Guid ownerId, Wedding data);
}
