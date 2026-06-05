using CentralTicket.Contexts.Events.DTOs.Event;
using CentralTicket.Contexts.Events.Entities;
using CentralTicket.Contexts.Events.Interfaces.IRepositories;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;
using CentralTicket.Contexts.Events.Data;
namespace CentralTicket.Contexts.Events.UseCases;

public class CreateEventUseCase : ICreateEventUseCase
{
    private readonly IEventRepository _eventRepository;

    public CreateEventUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<ReadEventDTO> ExecuteAsync(CreateEventDTO dto)
    {
        if (dto.StartDate >= dto.EndDate)
            throw new ArgumentException("Data de início deve ser anterior à data de fim");

        if (dto.StartDate < DateTime.UtcNow)
            throw new ArgumentException("Não é possível criar um evento no passado");

        if (dto.AmountTickets <= 0)
            throw new ArgumentException("Quantidade de ingressos deve ser maior que zero");

        if (dto.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo");

        var ev = new Event(
            dto.Title,
            dto.Description,
            dto.Location,
            dto.StartDate,
            dto.EndDate,
            dto.Price,
            dto.AmountTickets,
            dto.ImageUrl
        );

        await _eventRepository.AddAsync(ev);

        return MapToDTO(ev);
    }

    private ReadEventDTO MapToDTO(Event ev)
    {
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
