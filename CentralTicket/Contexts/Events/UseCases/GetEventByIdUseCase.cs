using CentralTicket.Contexts.Events.DTOs.Event;
using CentralTicket.Contexts.Events.Entities;
using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Events.UseCases;

public class GetEventByIdUseCase : IGetEventByIdUseCase
{
    private readonly IEventRepository _eventRepository;

    public GetEventByIdUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ReadEventDTO?> ExecuteAsync(Guid id)
    {
        var ev = await _eventRepository.GetByIdAsync(id);

        if (ev == null)
            return null;

        return new ReadEventDTO
        {
            Id = ev.Id,
            Title = ev.Title,
            Description = ev.Description,
            Location = ev.Location,
            ImageUrl = ev.ImageUrl,
            StartDate = ev.StartDate,
            EndDate = ev.EndDate,
            Status = ev.Status.ToString().ToLower(),
            Price = ev.Price,
            AmountTickets = ev.AmountTickets,
            RemainingTickets = ev.RemainingTickets,
            CreatedAt = ev.CreatedAt
        };
    }
}
