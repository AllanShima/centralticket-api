using CentralTicket.Contexts.Events.DTOs.Event;
using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Events.UseCases;

public class GetAllEventsUseCase : IGetAllEventsUseCase
{
    private readonly IEventRepository _eventRepository;

    public GetAllEventsUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<List<ReadEventDTO>> ExecuteAsync()
    {
        var events = await _eventRepository.GetAllAsync();

        var result = new List<ReadEventDTO>();

        foreach (var ev in events)
        {
            result.Add(new ReadEventDTO
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
            });
        }

        return result;
    }
}
