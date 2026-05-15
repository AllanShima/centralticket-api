namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class PaymentMethod
    {
        public int Value { get; private set; }

        enum Statuses
        {
            Debit,  // 0
            Credit, // 1
            Pix     // 2
        }

        public PaymentMethod(int value)
        {
            switch (value)
            {
                case (int)Statuses.Debit:
                    this.Value = value;
                    break;
                case (int)Statuses.Credit:
                    this.Value = value;
                    break;
                case (int)Statuses.Pix:
                    this.Value = value;
                    break;
                default:
                    throw new Exception("Status inválido.");
            }
        }

        public void Debit() => this.Value = 0;

        public void Credit() => this.Value = 1;

        public void Pix() => this.Value = 2;
    }
}
