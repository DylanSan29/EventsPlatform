using Microsoft.EntityFrameworkCore;
using InvitationContent.Api.Domain;

namespace InvitationContent.Api.Infrastructure.Data
{
    public class InvitationContentDbContext : DbContext
    {
        public InvitationContentDbContext(DbContextOptions<InvitationContentDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventSection> EventSections { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        
        // Optional: Map table names explicitly if they don't match pluralization
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<EventSection>().ToTable("EventSection");
            modelBuilder.Entity<EventImage>().ToTable("EventImage");
        }
    }
}