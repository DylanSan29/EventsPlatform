using Microsoft.EntityFrameworkCore;
using WeddingService.Api.Domain;

namespace WeddingService.Infrastructure;

public class WeddingRepository : IWeddingRepository
{
    private readonly WeddingDbContext _db;

    public WeddingRepository(WeddingDbContext db)
    {
        _db = db;
    }

    public async Task<Wedding> CreateAsync(Wedding wedding)
    {
        _db.Weddings.Add(wedding);
        await _db.SaveChangesAsync();
        return wedding;
    }

    public async Task<Wedding?> GetByIdAsync(Guid id)
    {
        return await _db.Weddings.FindAsync(id);
    }

    public async Task<Wedding?> GetByOwnerAsync(Guid ownerId)
    {
        return await _db.Weddings.FirstOrDefaultAsync(w => w.OwnerId == ownerId);
    }

    public async Task UpdateAsync(Wedding wedding)
    {
        wedding.UpdatedAt = DateTime.UtcNow;
        _db.Weddings.Update(wedding);
        await _db.SaveChangesAsync();
    }
}
