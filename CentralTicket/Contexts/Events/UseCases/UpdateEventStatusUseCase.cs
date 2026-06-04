using CentralTicket.Contexts.Events.Enums;
using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Events.UseCases;

public class UpdateEventStatusUseCase : IUpdateEventStatusUseCase
{
    private readonly IEventRepository _eventRepository;

    public UpdateEventStatusUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, string status)
    {
        var ev = await _eventRepository.GetByIdAsync(id);

        if (ev == null)
            return false;

        if (!Enum.TryParse<EventStatus>(status, true, out var parsedStatus))
            throw new ArgumentException($"Status inválido: {status}");

        ev.UpdateStatus(parsedStatus);
        await _eventRepository.UpdateAsync(ev);

        return true;
    }
}
