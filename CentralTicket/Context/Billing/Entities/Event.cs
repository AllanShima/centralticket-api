using CentralTicket.Entities;

namespace CentralTicket.Context.Billing.Entities
{
    public class Event : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketAmount { get; set; }
    }
}
