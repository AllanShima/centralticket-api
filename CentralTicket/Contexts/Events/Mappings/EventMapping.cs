using CentralTicket.Contexts.Events.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralTicket.Contexts.Events.Mappings;

public class EventMapping : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.Location)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.ImageUrl)
            .HasMaxLength(300);

        builder.Property(e => e.Price)
            .HasColumnType("decimal(10,2)");

        builder.Property(e => e.Status)
            .HasConversion<string>();

        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.EndDate).IsRequired();
        builder.Property(e => e.AmountTickets).IsRequired();
        builder.Property(e => e.RemainingTickets).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
    }
}
