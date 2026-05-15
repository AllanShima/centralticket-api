namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class Price
    {
        public float Value { get; private set; }

        public Price(float price)
        {
            if (price < 0) throw new Exception("Valor deve ser positivo");

            this.Value = price;
        }
    }
}
