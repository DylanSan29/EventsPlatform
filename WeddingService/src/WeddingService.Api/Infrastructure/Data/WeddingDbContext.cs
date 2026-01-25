using Microsoft.EntityFrameworkCore;
using WeddingService.Api.Domain;

namespace WeddingService.Infrastructure;

public class WeddingDbContext : DbContext
{
    public WeddingDbContext(DbContextOptions<WeddingDbContext> options)
        : base(options) { }

    public DbSet<Wedding> Weddings { get; set; }
}
