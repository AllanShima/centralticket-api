using CentralTicket.Contexts.Events.Enums;
using CentralTicket.Contexts.Events.ValueObjects;

namespace CentralTicket.Contexts.Events.Entities;

public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public string? ImageUrl { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public EventStatus Status { get; private set; } = EventStatus.Available;
    public decimal Price { get; private set; }
    public int AmountTickets { get; private set; }
    public int RemainingTickets { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // EF precisa do construtor sem parametros
    protected Event() { }

    public Event(string title, string description, string location, DateTime startDate, DateTime endDate, decimal price, int amountTickets, string? imageUrl = null)
    {
        Title = title;
        Description = description;
        Location = location;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
        AmountTickets = amountTickets;
        RemainingTickets = amountTickets;
        ImageUrl = imageUrl;
    }

    public void UpdateInfo(string title, string description, string location, string? imageUrl)
    {
        Title = title;
        Description = description;
        Location = location;
        ImageUrl = imageUrl;
    }

    // Esse metodo podia estar num UseCase mas ficou na entidade mesmo
    public void UpdateStatus(EventStatus status)
    {
        Status = status;
    }

    public bool DecrementTickets(int amount)
    {
        if (RemainingTickets < amount)
            return false;

        RemainingTickets -= amount;

        if (RemainingTickets == 0)
            Status = EventStatus.SoldOut;
        else if (RemainingTickets <= (AmountTickets * 0.1))
            Status = EventStatus.Shortly;

        return true;
    }

    public void IncrementTickets(int amount)
    {
        RemainingTickets += amount;

        if (Status == EventStatus.SoldOut && RemainingTickets > 0)
            Status = EventStatus.Available;
    }

    public bool IsPast() => EndDate < DateTime.UtcNow;
}
