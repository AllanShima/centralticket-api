using System.ComponentModel.DataAnnotations;

namespace CentralTicket.Contexts.Events.Requests;

public class CreateEventRequest
{
    [Required(ErrorMessage = "Título é obrigatório")]
    [MinLength(3, ErrorMessage = "Título deve ter ao menos 3 caracteres")]
    [MaxLength(100, ErrorMessage = "Título não pode ter mais de 100 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Descrição é obrigatória")]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Localização é obrigatória")]
    public string Location { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Preço não pode ser negativo")]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
    public int AmountTickets { get; set; }
}

public class UpdateEventRequest
{
    [Required(ErrorMessage = "Título é obrigatório")]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }
}

public class UpdateStatusRequest
{
    [Required(ErrorMessage = "Status é obrigatório")]
    public string Status { get; set; } = string.Empty;
}
