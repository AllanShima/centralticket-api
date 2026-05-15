namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class TicketStatus
    {
        public int Value { get; private set; }

        enum Statuses
        {
            Sold,      // 0
            Reserved,  // 1
            Available, // 2
        }

        public TicketStatus(int value)
        {
            switch (value)
            {
                case (int)Statuses.Sold:
                    this.Value = value;
                    break;
                case (int)Statuses.Reserved:
                    this.Value = value;
                    break;
                case (int)Statuses.Available:
                    this.Value = value;
                    break;
                default:
                    throw new Exception("Status inválido.");
            }
        }

        public void Sold()
        {
            this.Value = 0;
        }

        public void Reserved()
        {
            this.Value = 1;
        }

        public void Available()
        {
            this.Value = 2;
        }
    }
}
