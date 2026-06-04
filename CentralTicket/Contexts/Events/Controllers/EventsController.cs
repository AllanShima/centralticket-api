using CentralTicket.Contexts.Events.DTOs.Event;
using CentralTicket.Contexts.Events.Interfaces.IUseCases;
using CentralTicket.Contexts.Events.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CentralTicket.Contexts.Events.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IGetAllEventsUseCase _getAllEventsUseCase;
    private readonly IGetEventByIdUseCase _getEventByIdUseCase;
    private readonly ICreateEventUseCase _createEventUseCase;
    private readonly IUpdateEventUseCase _updateEventUseCase;
    private readonly IUpdateEventStatusUseCase _updateEventStatusUseCase;

    public EventsController(
        IGetAllEventsUseCase getAllEventsUseCase,
        IGetEventByIdUseCase getEventByIdUseCase,
        ICreateEventUseCase createEventUseCase,
        IUpdateEventUseCase updateEventUseCase,
        IUpdateEventStatusUseCase updateEventStatusUseCase)
    {
        _getAllEventsUseCase = getAllEventsUseCase;
        _getEventByIdUseCase = getEventByIdUseCase;
        _createEventUseCase = createEventUseCase;
        _updateEventUseCase = updateEventUseCase;
        _updateEventStatusUseCase = updateEventStatusUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _getAllEventsUseCase.ExecuteAsync();
        return Ok(events);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ev = await _getEventByIdUseCase.ExecuteAsync(id);

        if (ev == null)
            return NotFound(new { message = "Evento não encontrado" });

        return Ok(ev);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request)
    {
        var dto = new CreateEventDTO
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            ImageUrl = request.ImageUrl,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Price = request.Price,
            AmountTickets = request.AmountTickets
        };

        try
        {
            var result = await _createEventUseCase.ExecuteAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventRequest request)
    {
        var dto = new UpdateEventDTO
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            ImageUrl = request.ImageUrl
        };

        try
        {
            var result = await _updateEventUseCase.ExecuteAsync(id, dto);

            if (result == null)
                return NotFound(new { message = "Evento não encontrado" });

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStatusRequest request)
    {
        try
        {
            var updated = await _updateEventStatusUseCase.ExecuteAsync(id, request.Status);

            if (!updated)
                return NotFound(new { message = "Evento não encontrado" });

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}