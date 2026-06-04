using CentralTicket.Contexts.Events.Entities;

namespace CentralTicket.Contexts.Events.Interfaces.IRepositories;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid id);
    Task<List<Event>> GetAllAsync();
    Task AddAsync(Event ev);
    Task UpdateAsync(Event ev);
}
