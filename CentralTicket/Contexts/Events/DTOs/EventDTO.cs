namespace CentralTicket.Contexts.Events.DTOs.Event;

public class CreateEventDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public int AmountTickets { get; set; }
}

public class UpdateEventDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}

public class ReadEventDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    // status como string pra facilitar no front
    public string Status { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int AmountTickets { get; set; }
    public int RemainingTickets { get; set; }
    public DateTime CreatedAt { get; set; }
}
