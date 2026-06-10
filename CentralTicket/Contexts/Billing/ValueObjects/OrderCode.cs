namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class OrderCode
    {
        public Guid Value { get; private set; }

        public OrderCode(Guid orderCode)
        {
            if (orderCode == null) throw new ArgumentNullException("Código precisa ser preenchido");

            this.Value = orderCode;
        }

        private OrderCode() { }
    }
}
