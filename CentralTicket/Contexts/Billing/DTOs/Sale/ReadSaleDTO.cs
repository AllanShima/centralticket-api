using CentralTicket.Contexts.Billing.Entities;
using CentralTicket.Contexts.Billing.Enums;
using CentralTicket.Contexts.Billing.ValueObjects;
using CentralTicket.DTOs.Base;

namespace CentralTicket.Contexts.Billing.DTOs.Sale
{
    public class ReadSaleDTO : ReadBaseDTO
    {
        public Price TotalValue { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Crédito, Débito
        public SaleStatus Status { get; set; }
        public OrderCode OrderCode { get; set; }
        public Guid CustomerId { get; set; }
        public List<Contexts.Billing.Entities.Ticket> PurchasedTickets { get; set; }
    }
}
