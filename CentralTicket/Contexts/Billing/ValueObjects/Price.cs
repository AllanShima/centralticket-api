namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class Price
    {
        public decimal Value { get; private set; }

        public Price(decimal value)
        {
            if (value < 0) throw new Exception("Valor deve ser positivo");

            this.Value = value;
        }

        private Price() { }
    }
}
