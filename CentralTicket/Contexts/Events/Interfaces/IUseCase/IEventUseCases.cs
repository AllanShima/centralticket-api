using CentralTicket.Contexts.Events.DTOs.Event;

namespace CentralTicket.Contexts.Events.Interfaces.IUseCases;

public interface ICreateEventUseCase
{
    Task<ReadEventDTO> ExecuteAsync(CreateEventDTO dto);
}

public interface IGetEventByIdUseCase
{
    Task<ReadEventDTO?> ExecuteAsync(Guid id);
}

public interface IGetAllEventsUseCase
{
    Task<List<ReadEventDTO>> ExecuteAsync();
}

public interface IUpdateEventUseCase
{
    Task<ReadEventDTO?> ExecuteAsync(Guid id, UpdateEventDTO dto);
}

public interface IUpdateEventStatusUseCase
{
    Task<bool> ExecuteAsync(Guid id, string status);
}

public interface IUpdateTicketsRemainingUseCase
{
    Task<bool> ExecuteAsync(Guid eventId, int amount);
}
