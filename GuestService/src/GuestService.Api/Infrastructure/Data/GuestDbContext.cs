using Microsoft.EntityFrameworkCore;
using GuestService.Api.Domain;

namespace GuestService.Api.Infrastructure.Data
{
    public class GuestDbContext : DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options) { }
        public DbSet<Guest> Guests { get; set; }
    }
}