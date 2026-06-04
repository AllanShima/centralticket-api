using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Events.UseCases;

public class UpdateTicketsRemainingUseCase : IUpdateTicketsRemainingUseCase
{
    private readonly IEventRepository _eventRepository;

    public UpdateTicketsRemainingUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<bool> ExecuteAsync(Guid eventId, int amount)
    {
        var ev = await _eventRepository.GetByIdAsync(eventId);

        if (ev == null)
            return false;

        bool success;

        if (amount < 0)
        {
            ev.IncrementTickets(Math.Abs(amount));
            success = true;
        }
        else
        {
            success = ev.DecrementTickets(amount);
        }

        if (success)
            await _eventRepository.UpdateAsync(ev);

        return success;
    }
}
