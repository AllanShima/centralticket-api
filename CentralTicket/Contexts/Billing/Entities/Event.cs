using CentralTicket.Contexts.Billing.ValueObjects;
using CentralTicket.Entities;

namespace CentralTicket.Contexts.Billing.Entities
{
    public class Event : Base
    {
        public Title Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
