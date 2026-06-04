using CentralTicket.Contexts.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentralTicket.Contexts.Events.Data;

public class EventsDbContext : DbContext
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Events");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Description)
                  .IsRequired();

            entity.Property(e => e.Status)
                  .HasConversion<string>()
                  .IsRequired();

            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Location)
                  .IsRequired()
                  .HasMaxLength(300);

            entity.Property(e => e.ImageUrl)
                  .HasMaxLength(500);
        });
    }
}