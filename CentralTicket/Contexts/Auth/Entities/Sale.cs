using CentralTicket.Contexts.Auth.Entities;
using CentralTicket.Entities;

namespace CentralTicket.Contexts.Auth.Entities
{
    public class Sale : Base
    {
        public decimal TotalValue { get; private set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string OrderCode { get; set; }
        public string Customer { get; set; }
        public List<Ticket> PurchasedTickets { get; set; }
    }
}
