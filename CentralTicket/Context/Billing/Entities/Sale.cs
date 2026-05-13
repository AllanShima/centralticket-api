using CentralTicket.Entities;

namespace CentralTicket.Context.Billing.Entities
{
    public class Sale : Base
    {
        public float TotalValue { get; private set; }
        public int PaymentMethod {  get; set; } // Crédito, Débito
        public int Status { get; set; } // Aprovado, Aguardando pagamento, cancelado
        public string OrderCode { get; set; }
        public User Customer { get; set; }
        public List<Ticket> PurchasedTickets { get; set; }
    }
}
