using Microsoft.EntityFrameworkCore;
using ManagementService.Api.Domain;

namespace ManagementService.Api.Infrastructure.Data
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
    }
}