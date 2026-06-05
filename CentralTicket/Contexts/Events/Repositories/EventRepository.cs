using CentralTicket.Contexts.Events.Data;
using CentralTicket.Contexts.Events.Entities;
using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace CentralTicket.Contexts.Events.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventsDbContext _context;

    public EventRepository(EventsDbContext context)
    {
        _context = context;
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Event>> GetAllAsync()
    {
        // retorna todos sem filtro por ora
        return await _context.Events.OrderByDescending(e => e.CreatedAt).ToListAsync();
    }

    public async Task AddAsync(Event ev)
    {
        await _context.Events.AddAsync(ev);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Event ev)
    {
        _context.Events.Update(ev);
        await _context.SaveChangesAsync();
    }
}
