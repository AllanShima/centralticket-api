using CentralTicket.Contexts.Events.DTOs.Event;
using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Events.UseCases;

public class UpdateEventUseCase : IUpdateEventUseCase
{
    private readonly IEventRepository _eventRepository;

    public UpdateEventUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ReadEventDTO?> ExecuteAsync(Guid id, UpdateEventDTO dto)
    {
        var ev = await _eventRepository.GetByIdAsync(id);

        if (ev == null)
            return null;

        if (ev.IsPast())
            throw new InvalidOperationException("Não é possível atualizar um evento que já ocorreu");

        ev.UpdateInfo(dto.Title, dto.Description, dto.Location, dto.ImageUrl);

        await _eventRepository.UpdateAsync(ev);

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
