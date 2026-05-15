namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class SaleStatus
    {
        public int Value { get; private set; }

        enum Statuses
        {
            Canceled,         // 0
            AwaitingApproval, // 1
            Approved          // 2
        }

        public SaleStatus(int value)
        {
            switch (value)
            {
                case (int)Statuses.Canceled:
                    this.Value = value;
                    break;
                case (int)Statuses.AwaitingApproval:
                    this.Value = value;
                    break;
                case (int)Statuses.Approved:
                    this.Value = value;
                    break;
                default:
                    throw new Exception("Status inválido.");
            }
        }

        public void Canceled() => this.Value = 0;
        
        public void AwaitingApproval() => this.Value = 1;
        
        public void Approved() => this.Value = 2;
    }
}
