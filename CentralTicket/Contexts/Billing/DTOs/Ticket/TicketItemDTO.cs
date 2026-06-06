using CentralTicket.Contexts.Billing.Enums;

namespace CentralTicket.Contexts.Billing.DTOs.Ticket
{
    public class TicketItemDTO
    {
        public Category Category { get; set; }
        public Kind Kind { get; set; }
    }
}
