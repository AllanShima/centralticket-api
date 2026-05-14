using CentralTicket.Entities;

namespace CentralTicket.Contexts.Billing.Entities
{
    public class Ticket : Base
    {
        public float Value { get; private set; }
        public int Category {  get; set; } // meia, inteira
        public int Kind { get; set; } // VIP, arquibancada, camarote
        public int Status { get; private set; } // vendido, disponível
        public Event Event { get; set; }
    }
}
