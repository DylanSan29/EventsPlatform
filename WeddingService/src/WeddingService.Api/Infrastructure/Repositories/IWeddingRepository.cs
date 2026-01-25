using WeddingService.Api.Domain;

namespace WeddingService.Infrastructure;

public interface IWeddingRepository
{
    Task<Wedding> CreateAsync(Wedding wedding);
    Task<Wedding?> GetByIdAsync(Guid id);
    Task<Wedding?> GetByOwnerAsync(Guid ownerId);
    Task UpdateAsync(Wedding wedding);
}
