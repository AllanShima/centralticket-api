 namespace CentralTicket.Contexts.Billing.DTOs.Sale
{
    public class CreateSaleDTO
    {
        public float TotalValue { get; private set; }
        public int PaymentMethod { get; set; }
        public int UserId { get; set; }
        public List<int> TicketsId { get; set; }
    }
}
