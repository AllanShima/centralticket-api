using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.DTOs.Sale
{
    public class ReadSaleDTO
    {
        public Guid Id { get; set; }
        public float TotalValue { get; set; }
        public int PaymentMethod { get; set; } // Crédito, Débito
        public int Status { get; set; } // Aprovado, Aguardando pagamento, cancelado
        public string OrderCode { get; set; }
        public User Customer { get; set; }
        public List<Ticket> PurchasedTickets { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
